namespace Infrastructure.ServicosExternos.Keycloak;

/// <summary>
/// Interface para serviço de armazenamento seguro de credenciais.
/// Implementações concretas devem usar APIs específicas da plataforma.
/// No MAUI: SecureStorage (Android Keystore, iOS Keychain, etc)
/// </summary>
public interface ISecureStorageService
{
    /// <summary>
    /// Salva o access token de forma segura.
    /// </summary>
    Task SalvarAccessTokenAsync(string accessToken);

    /// <summary>
    /// Obtém o access token armazenado.
    /// </summary>
    Task<string?> ObterAccessTokenAsync();

    /// <summary>
    /// Salva o refresh token de forma segura.
    /// </summary>
    Task SalvarRefreshTokenAsync(string refreshToken);

    /// <summary>
    /// Obtém o refresh token armazenado.
    /// </summary>
    Task<string?> ObterRefreshTokenAsync();

    /// <summary>
    /// Salva a data de expiração do token.
    /// </summary>
    Task SalvarTokenExpirationAsync(DateTime expiration);

    /// <summary>
    /// Obtém a data de expiração do token.
    /// </summary>
    Task<DateTime?> ObterTokenExpirationAsync();

    /// <summary>
    /// Verifica se o token está expirado.
    /// </summary>
    Task<bool> TokenEstaExpiradoAsync();

    /// <summary>
    /// Salva informações do usuário.
    /// </summary>
    Task SalvarInformacoesUsuarioAsync(string userId, string email, string name);

    /// <summary>
    /// Obtém o ID do usuário armazenado.
    /// </summary>
    Task<string?> ObterUserIdAsync();

    /// <summary>
    /// Obtém o email do usuário armazenado.
    /// </summary>
    Task<string?> ObterUserEmailAsync();

    /// <summary>
    /// Obtém o nome do usuário armazenado.
    /// </summary>
    Task<string?> ObterUserNameAsync();

    /// <summary>
    /// Remove todos os dados armazenados.
    /// </summary>
    void LimparTudo();

    /// <summary>
    /// Verifica se existe um usuário autenticado.
    /// </summary>
    Task<bool> ExisteUsuarioAutenticadoAsync();
}

