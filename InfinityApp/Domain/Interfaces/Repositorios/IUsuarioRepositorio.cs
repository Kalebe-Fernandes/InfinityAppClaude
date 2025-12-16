using Domain.Entidades.Comum;

namespace Domain.Interfaces.Repositorios;

/// <summary>
/// Interface para repositório de Usuários.
/// </summary>
public interface IUsuarioRepositorio : IRepositorio<Usuario>
{
    /// <summary>
    /// Obtém um usuário pelo email.
    /// </summary>
    Task<Usuario?> ObterPorEmailAsync(string email);

    /// <summary>
    /// Obtém um usuário pelo username do Keycloak.
    /// </summary>
    Task<Usuario?> ObterPorUsernameAsync(string username);
}
