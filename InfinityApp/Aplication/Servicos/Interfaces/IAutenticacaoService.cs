using Aplication.DTOs.Autenticacao;

namespace Aplication.Servicos.Interfaces;

/// <summary>
/// Interface para serviço de autenticação.
/// </summary>
public interface IAutenticacaoService
{
    /// <summary>
    /// Realiza o login do usuário via Keycloak.
    /// </summary>
    Task<string> LoginAsync();

    /// <summary>
    /// Realiza o logout do usuário.
    /// </summary>
    Task<bool> LogoutAsync();

    /// <summary>
    /// Verifica se o usuário está autenticado.
    /// </summary>
    Task<bool> EstaAutenticadoAsync();

    /// <summary>
    /// Obtém o Refresh Token armazenado.
    /// </summary>
    Task<string?> ObterRefreshTokenAsync();

    /// <summary>
    /// Obtém o access token atual.
    /// </summary>
    Task<string?> ObterAccessTokenAsync();

    /// <summary>
    /// Renova o Refresh Token.
    /// </summary>
    Task<bool> RenovarTokenAsync();

    /// <summary>
    /// Obtém as informações do usuário autenticado.
    /// </summary>
    Task<UsuarioDto?> ObterInformacoesUsuarioAsync();

    /// <summary>
    /// Verifica se o token está próximo de expirar (24 horas).
    /// </summary>
    Task<bool> TokenProximoExpirarAsync();

    /// <summary>
    /// Processa o callback após autenticação.
    /// Troca o código de autorização por tokens.
    /// </summary>
    Task<TokenDto?> ProcessarCallbackAsync(string callbackUrl);
}
