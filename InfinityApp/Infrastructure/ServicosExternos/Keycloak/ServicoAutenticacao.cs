using Aplication.DTOs.Autenticacao;
using Aplication.Servicos.Interfaces;
using Infrastructure.Configuracoes;
using Infrastructure.ServicosExternos.Keycloak.Seguranca;

namespace Infrastructure.ServicosExternos.Keycloak;

/// <summary>
/// Implementação do serviço de autenticação com Keycloak.
/// Utiliza OAuth 2.0 + OIDC + PKCE para autenticação segura.
/// </summary>
public class ServicoAutenticacao(KeycloakConfig config, KeycloakHttpClient httpClient, ISecureStorageService secureStorage) : IAutenticacaoService
{
    private readonly KeycloakConfig _config = config;
    private readonly KeycloakHttpClient _httpClient = httpClient;
    private readonly ISecureStorageService _secureStorage = secureStorage;

    private string? _codeVerifier;
    private string? _state;

    /// <summary>
    /// Realiza login do usuário.
    /// Gera a URL de autorização com PKCE para abertura no navegador.
    /// </summary>
    public async Task<string> LoginAsync()
    {
        // Gerar PKCE
        _codeVerifier = PkceGenerator.GerarCodeVerifier();
        var codeChallenge = PkceGenerator.GerarCodeChallenge(_codeVerifier);
        _state = PkceGenerator.GerarState();

        // Construir URL de autorização
        var parametros = new Dictionary<string, string>
        {
            { "client_id", _config.ClientId },
            { "redirect_uri", _config.RedirectUri },
            { "response_type", "code" },
            { "scope", _config.Scopes },
            { "code_challenge", codeChallenge },
            { "code_challenge_method", "S256" },
            { "state", _state }
        };

        var queryString = string.Join("&", parametros.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value)}"));
        var authUrl = $"{_config.AuthorizationEndpoint}?{queryString}";

        return await Task.FromResult(authUrl);
    }

    /// <summary>
    /// Processa o callback após autenticação.
    /// Troca o código de autorização por tokens.
    /// </summary>
    public async Task<TokenDto?> ProcessarCallbackAsync(string callbackUrl)
    {
        // Extrair parâmetros da URL
        var uri = new Uri(callbackUrl);
        var parametros = System.Web.HttpUtility.ParseQueryString(uri.Query);

        var code = parametros["code"];
        var state = parametros["state"];
        var error = parametros["error"];

        // Validar state
        if (state != _state)
        {
            throw new InvalidOperationException("State inválido. Possível ataque CSRF.");
        }

        // Verificar erro
        if (!string.IsNullOrEmpty(error))
        {
            throw new InvalidOperationException($"Erro na autenticação: {error}");
        }

        // Verificar código
        if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(_codeVerifier))
        {
            throw new InvalidOperationException("Código de autorização não recebido.");
        }

        // Trocar código por tokens
        var tokenResponse = await _httpClient.TrocarCodigoPorTokenAsync(code, _codeVerifier);
        if (tokenResponse == null)
        {
            return null;
        }

        // Salvar tokens
        await _secureStorage.SalvarAccessTokenAsync(tokenResponse.AccessToken);
        await _secureStorage.SalvarRefreshTokenAsync(tokenResponse.RefreshToken);

        var expiration = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn);
        await _secureStorage.SalvarTokenExpirationAsync(expiration);

        // Obter informações do usuário
        var userInfo = await _httpClient.ObterInformacoesUsuarioAsync(tokenResponse.AccessToken);
        if (userInfo != null)
        {
            await _secureStorage.SalvarInformacoesUsuarioAsync(
                userInfo.Sub,
                userInfo.Email,
                userInfo.Name
            );
        }

        // Limpar state e code verifier
        _state = null;
        _codeVerifier = null;

        return new TokenDto
        {
            AccessToken = tokenResponse.AccessToken,
            RefreshToken = tokenResponse.RefreshToken,
            ExpiresIn = tokenResponse.ExpiresIn
        };
    }

    /// <summary>
    /// Realiza logout do usuário.
    /// </summary>
    public async Task<bool> LogoutAsync()
    {
        try
        {
            // Obter refresh token
            var refreshToken = await _secureStorage.ObterRefreshTokenAsync();

            if (!string.IsNullOrEmpty(refreshToken))
            {
                // Revogar token no servidor
                await _httpClient.RevogarTokenAsync(refreshToken);
            }

            // Limpar armazenamento local
            _secureStorage.LimparTudo();

            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Verifica se o usuário está autenticado.
    /// </summary>
    public async Task<bool> EstaAutenticadoAsync()
    {
        var existeUsuario = await _secureStorage.ExisteUsuarioAutenticadoAsync();
        if (!existeUsuario)
            return false;

        // Verificar se o token está expirado
        var tokenExpirado = await _secureStorage.TokenEstaExpiradoAsync();
        if (tokenExpirado)
        {
            // Tentar renovar token
            return await RenovarTokenAsync();
        }

        return true;
    }

    /// <summary>
    /// Renova o access token usando o refresh token.
    /// </summary>
    public async Task<bool> RenovarTokenAsync()
    {
        try
        {
            var refreshToken = await _secureStorage.ObterRefreshTokenAsync();
            if (string.IsNullOrEmpty(refreshToken))
                return false;

            var tokenResponse = await _httpClient.RenovarTokenAsync(refreshToken);
            if (tokenResponse == null)
                return false;

            // Atualizar tokens
            await _secureStorage.SalvarAccessTokenAsync(tokenResponse.AccessToken);
            await _secureStorage.SalvarRefreshTokenAsync(tokenResponse.RefreshToken);

            var expiration = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn);
            await _secureStorage.SalvarTokenExpirationAsync(expiration);

            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Obtém o access token atual.
    /// </summary>
    public async Task<string?> ObterAccessTokenAsync()
    {
        // Verificar se token está expirado
        var tokenExpirado = await _secureStorage.TokenEstaExpiradoAsync();
        if (tokenExpirado)
        {
            // Tentar renovar
            var renovado = await RenovarTokenAsync();
            if (!renovado)
                return null;
        }

        return await _secureStorage.ObterAccessTokenAsync();
    }

    /// <summary>
    /// Obtém informações do usuário autenticado.
    /// </summary>
    public async Task<UsuarioDto?> ObterUsuarioAtualAsync()
    {
        var userId = await _secureStorage.ObterUserIdAsync();
        var email = await _secureStorage.ObterUserEmailAsync();
        var name = await _secureStorage.ObterUserNameAsync();

        if (string.IsNullOrEmpty(userId))
            return null;

        return new UsuarioDto
        {
            Id = Guid.Parse(userId),
            Nome = name ?? string.Empty,
            Email = email ?? string.Empty,
            Username = email ?? string.Empty
        };
    }

    public async Task<string?> ObterRefreshTokenAsync()
    {
        return await _secureStorage.ObterRefreshTokenAsync();
    }

    public async Task<UsuarioDto?> ObterInformacoesUsuarioAsync()
    {
        return await ObterUsuarioAtualAsync();
    }

    public async Task<bool> TokenProximoExpirarAsync()
    {
        var expiration = await _secureStorage.ObterTokenExpirationAsync();
        if (expiration == null)
            return true;

        // Verificar se expira em menos de 24 horas
        var tempoRestante = expiration.Value - DateTime.UtcNow;
        return tempoRestante.TotalHours < 24;
    }
}
