using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Infrastructure.Configuracoes;

namespace Infrastructure.ServicosExternos.Keycloak;

/// <summary>
/// Cliente HTTP para comunicação com o Keycloak.
/// </summary>
public class KeycloakHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly KeycloakConfig _config;
    private readonly JsonSerializerOptions _jsonOptions;

    public KeycloakHttpClient(HttpClient httpClient, KeycloakConfig config)
    {
        _httpClient = httpClient;
        _config = config;

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    /// <summary>
    /// Troca o código de autorização por tokens (access token + refresh token).
    /// </summary>
    public async Task<TokenResponse?> TrocarCodigoPorTokenAsync(
        string code,
        string codeVerifier,
        CancellationToken cancellationToken = default)
    {
        var parametros = new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "client_id", _config.ClientId },
            { "code", code },
            { "redirect_uri", _config.RedirectUri },
            { "code_verifier", codeVerifier }
        };

        return await ExecutarRequisicaoTokenAsync(parametros, cancellationToken);
    }

    /// <summary>
    /// Renova o access token usando o refresh token.
    /// </summary>
    public async Task<TokenResponse?> RenovarTokenAsync(
        string refreshToken,
        CancellationToken cancellationToken = default)
    {
        var parametros = new Dictionary<string, string>
        {
            { "grant_type", "refresh_token" },
            { "client_id", _config.ClientId },
            { "refresh_token", refreshToken }
        };

        return await ExecutarRequisicaoTokenAsync(parametros, cancellationToken);
    }

    /// <summary>
    /// Obtém informações do usuário autenticado.
    /// </summary>
    public async Task<UserInfoResponse?> ObterInformacoesUsuarioAsync(
        string accessToken,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync(_config.UserInfoEndpoint, cancellationToken);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<UserInfoResponse>(_jsonOptions, cancellationToken);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Revoga um token (access ou refresh).
    /// </summary>
    public async Task<bool> RevogarTokenAsync(
        string token,
        string tokenTypeHint = "refresh_token",
        CancellationToken cancellationToken = default)
    {
        try
        {
            var parametros = new Dictionary<string, string>
            {
                { "client_id", _config.ClientId },
                { "token", token },
                { "token_type_hint", tokenTypeHint }
            };

            var content = new FormUrlEncodedContent(parametros);
            var response = await _httpClient.PostAsync(_config.RevocationEndpoint, content, cancellationToken);

            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Executa uma requisição ao endpoint de token.
    /// </summary>
    private async Task<TokenResponse?> ExecutarRequisicaoTokenAsync(
        Dictionary<string, string> parametros,
        CancellationToken cancellationToken)
    {
        try
        {
            var content = new FormUrlEncodedContent(parametros);
            var response = await _httpClient.PostAsync(_config.TokenEndpoint, content, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadFromJsonAsync<ErrorResponse>(_jsonOptions, cancellationToken);
                return null;
            }

            return await response.Content.ReadFromJsonAsync<TokenResponse>(_jsonOptions, cancellationToken);
        }
        catch
        {
            return null;
        }
    }
}
