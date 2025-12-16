namespace Aplication.DTOs.Autenticacao;

/// <summary>
/// DTO com informações do usuário autenticado.
/// </summary>
public class UsuarioDto
{
    /// <summary>
    /// ID do usuário no sistema local.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ID do usuário no Keycloak (Subject).
    /// </summary>
    public string KeycloakId { get; set; } = string.Empty;

    /// <summary>
    /// Nome completo do usuário.
    /// </summary>
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Email do usuário.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Username do Keycloak.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Indica se o email foi verificado.
    /// </summary>
    public bool EmailVerificado { get; set; }

    /// <summary>
    /// Data do último login.
    /// </summary>
    public DateTime? UltimoLogin { get; set; }
}
