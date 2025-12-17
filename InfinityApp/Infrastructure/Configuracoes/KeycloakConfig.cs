namespace Infrastructure.Configuracoes;

/// <summary>
/// Configurações do Keycloak para autenticação OAuth 2.0 / OIDC.
/// </summary>
public class KeycloakConfig
{
    /// <summary>
    /// URL base do servidor Keycloak.
    /// Exemplo: https://auth.caiapoconstrucoes.com.br
    /// </summary>
    public string Authority { get; set; } = string.Empty;

    /// <summary>
    /// Realm do Keycloak.
    /// Exemplo: infinity-realm
    /// </summary>
    public string Realm { get; set; } = string.Empty;

    /// <summary>
    /// Client ID da aplicação.
    /// Exemplo: infinity-app
    /// </summary>
    public string ClientId { get; set; } = string.Empty;

    /// <summary>
    /// Redirect URI para callback após autenticação.
    /// Exemplo: infinityapp://callback
    /// </summary>
    public string RedirectUri { get; set; } = string.Empty;

    /// <summary>
    /// Scopes solicitados.
    /// Exemplo: openid profile email offline_access
    /// </summary>
    public string Scopes { get; set; } = "openid profile email offline_access";

    /// <summary>
    /// URL completa do endpoint de autorização.
    /// </summary>
    public string AuthorizationEndpoint => $"{Authority}/realms/{Realm}/protocol/openid-connect/auth";

    /// <summary>
    /// URL completa do endpoint de token.
    /// </summary>
    public string TokenEndpoint => $"{Authority}/realms/{Realm}/protocol/openid-connect/token";

    /// <summary>
    /// URL completa do endpoint de logout.
    /// </summary>
    public string LogoutEndpoint => $"{Authority}/realms/{Realm}/protocol/openid-connect/logout";

    /// <summary>
    /// URL completa do endpoint de user info.
    /// </summary>
    public string UserInfoEndpoint => $"{Authority}/realms/{Realm}/protocol/openid-connect/userinfo";

    /// <summary>
    /// URL completa do endpoint de revogação de token.
    /// </summary>
    public string RevocationEndpoint => $"{Authority}/realms/{Realm}/protocol/openid-connect/revoke";

    /// <summary>
    /// Tempo de expiração do token em segundos (padrão: 5 minutos).
    /// </summary>
    public int TokenExpirationSeconds { get; set; } = 300;

    /// <summary>
    /// Tempo de expiração do refresh token em segundos (padrão: 30 dias).
    /// </summary>
    public int RefreshTokenExpirationSeconds { get; set; } = 2592000;
}
