using Domain.Entidades.Base;

namespace Domain.Entidades.Comum;

/// <summary>
/// Representa um usuário do sistema.
/// </summary>
public class Usuario : EntidadeBase
{
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
    /// Username do Keycloak (preferred_username).
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Indica se o email do usuário foi verificado.
    /// </summary>
    public bool EmailVerificado { get; set; }

    /// <summary>
    /// Data do último login do usuário.
    /// </summary>
    public DateTime? UltimoLogin { get; set; }

    /// <summary>
    /// Indica se o usuário está ativo no sistema.
    /// </summary>
    public bool Ativo { get; set; }

    /// <summary>
    /// Registra o login do usuário.
    /// </summary>
    public void RegistrarLogin()
    {
        UltimoLogin = DateTime.UtcNow;
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Ativa o usuário.
    /// </summary>
    public void Ativar()
    {
        Ativo = true;
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Desativa o usuário.
    /// </summary>
    public void Desativar()
    {
        Ativo = false;
        AtualizarDataAtualizacao();
    }
}
