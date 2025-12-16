namespace Aplication.DTOs.Autenticacao;

/// <summary>
/// DTO para dados de login do usuário.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// Code Verifier gerado para o fluxo PKCE.
    /// </summary>
    public string CodeVerifier { get; set; } = string.Empty;

    /// <summary>
    /// Code Challenge derivado do Code Verifier.
    /// </summary>
    public string CodeChallenge { get; set; } = string.Empty;

    /// <summary>
    /// URL de redirecionamento após autenticação.
    /// </summary>
    public string RedirectUri { get; set; } = "infinityapp://oauth2redirect";

    /// <summary>
    /// Authorization Code retornado pelo Keycloak.
    /// </summary>
    public string? AuthorizationCode { get; set; }
}
