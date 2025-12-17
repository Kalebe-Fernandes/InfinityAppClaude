using Infrastructure.ServicosExternos.Keycloak;

namespace Apresentacao.Services;

/// <summary>
/// Implementação MAUI do serviço de armazenamento seguro.
/// Usa SecureStorage do .NET MAUI que implementa:
/// - Android: Android Keystore (hardware-backed encryption)
/// - iOS: iOS Keychain
/// - Windows: Data Protection API
/// </summary>
public class MauiSecureStorageService : ISecureStorageService
{
    private const string AccessTokenKey = "infinity_access_token";
    private const string RefreshTokenKey = "infinity_refresh_token";
    private const string TokenExpirationKey = "infinity_token_expiration";
    private const string UserIdKey = "infinity_user_id";
    private const string UserEmailKey = "infinity_user_email";
    private const string UserNameKey = "infinity_user_name";

    /// <summary>
    /// Salva o access token de forma segura.
    /// </summary>
    public async Task SalvarAccessTokenAsync(string accessToken)
    {
        await SecureStorage.Default.SetAsync(AccessTokenKey, accessToken);
    }

    /// <summary>
    /// Obtém o access token armazenado.
    /// </summary>
    public async Task<string?> ObterAccessTokenAsync()
    {
        return await SecureStorage.Default.GetAsync(AccessTokenKey);
    }

    /// <summary>
    /// Salva o refresh token de forma segura.
    /// </summary>
    public async Task SalvarRefreshTokenAsync(string refreshToken)
    {
        await SecureStorage.Default.SetAsync(RefreshTokenKey, refreshToken);
    }

    /// <summary>
    /// Obtém o refresh token armazenado.
    /// </summary>
    public async Task<string?> ObterRefreshTokenAsync()
    {
        return await SecureStorage.Default.GetAsync(RefreshTokenKey);
    }

    /// <summary>
    /// Salva a data de expiração do token.
    /// </summary>
    public async Task SalvarTokenExpirationAsync(DateTime expiration)
    {
        await SecureStorage.Default.SetAsync(TokenExpirationKey, expiration.ToString("O"));
    }

    /// <summary>
    /// Obtém a data de expiração do token.
    /// </summary>
    public async Task<DateTime?> ObterTokenExpirationAsync()
    {
        var value = await SecureStorage.Default.GetAsync(TokenExpirationKey);
        if (string.IsNullOrEmpty(value))
            return null;

        if (DateTime.TryParse(value, out var expiration))
            return expiration;

        return null;
    }

    /// <summary>
    /// Verifica se o token está expirado.
    /// </summary>
    public async Task<bool> TokenEstaExpiradoAsync()
    {
        var expiration = await ObterTokenExpirationAsync();
        if (!expiration.HasValue)
            return true;

        // Considera expirado se faltar menos de 1 minuto
        return expiration.Value.AddMinutes(-1) <= DateTime.UtcNow;
    }

    /// <summary>
    /// Salva informações do usuário.
    /// </summary>
    public async Task SalvarInformacoesUsuarioAsync(string userId, string email, string name)
    {
        await SecureStorage.Default.SetAsync(UserIdKey, userId);
        await SecureStorage.Default.SetAsync(UserEmailKey, email);
        await SecureStorage.Default.SetAsync(UserNameKey, name);
    }

    /// <summary>
    /// Obtém o ID do usuário armazenado.
    /// </summary>
    public async Task<string?> ObterUserIdAsync()
    {
        return await SecureStorage.Default.GetAsync(UserIdKey);
    }

    /// <summary>
    /// Obtém o email do usuário armazenado.
    /// </summary>
    public async Task<string?> ObterUserEmailAsync()
    {
        return await SecureStorage.Default.GetAsync(UserEmailKey);
    }

    /// <summary>
    /// Obtém o nome do usuário armazenado.
    /// </summary>
    public async Task<string?> ObterUserNameAsync()
    {
        return await SecureStorage.Default.GetAsync(UserNameKey);
    }

    /// <summary>
    /// Remove todos os dados armazenados.
    /// </summary>
    public void LimparTudo()
    {
        SecureStorage.Default.Remove(AccessTokenKey);
        SecureStorage.Default.Remove(RefreshTokenKey);
        SecureStorage.Default.Remove(TokenExpirationKey);
        SecureStorage.Default.Remove(UserIdKey);
        SecureStorage.Default.Remove(UserEmailKey);
        SecureStorage.Default.Remove(UserNameKey);
    }

    /// <summary>
    /// Verifica se existe um usuário autenticado.
    /// </summary>
    public async Task<bool> ExisteUsuarioAutenticadoAsync()
    {
        var accessToken = await ObterAccessTokenAsync();
        var refreshToken = await ObterRefreshTokenAsync();

        return !string.IsNullOrEmpty(accessToken) || !string.IsNullOrEmpty(refreshToken);
    }
}
