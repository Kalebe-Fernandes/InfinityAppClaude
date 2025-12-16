namespace Domain.Interfaces.Servicos;

/// <summary>
/// Interface para serviço de autenticação.
/// </summary>
public interface IAutenticacaoService
{
    /// <summary>
    /// Realiza o login do usuário via Keycloak.
    /// </summary>
    Task<bool> RealizarLoginAsync();

    /// <summary>
    /// Realiza o logout do usuário.
    /// </summary>
    Task RealizarLogoutAsync();

    /// <summary>
    /// Verifica se o usuário está autenticado.
    /// </summary>
    Task<bool> EstaAutenticadoAsync();

    /// <summary>
    /// Obtém o Refresh Token armazenado.
    /// </summary>
    Task<string?> ObterRefreshTokenAsync();

    /// <summary>
    /// Renova o Refresh Token.
    /// </summary>
    Task<bool> RenovarTokenAsync();

    /// <summary>
    /// Obtém as informações do usuário autenticado.
    /// </summary>
    Task<object?> ObterInformacoesUsuarioAsync();

    /// <summary>
    /// Verifica se o token está próximo de expirar (24 horas).
    /// </summary>
    Task<bool> TokenProximoExpirarAsync();
}
