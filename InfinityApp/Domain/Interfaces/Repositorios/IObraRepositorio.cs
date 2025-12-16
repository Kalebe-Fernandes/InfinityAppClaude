using Domain.Entidades.Comum;

namespace Domain.Interfaces.Repositorios;

/// <summary>
/// Interface para repositório de Obras.
/// Herda operações básicas de IRepositorio e adiciona métodos específicos de Obra.
/// </summary>
public interface IObraRepositorio : IRepositorio<Obra>
{
    /// <summary>
    /// Obtém todas as obras ativas.
    /// </summary>
    /// <returns>Lista de obras ativas.</returns>
    Task<IEnumerable<Obra>> ObterObrasAtivasAsync();

    /// <summary>
    /// Obtém obras associadas a um usuário específico.
    /// </summary>
    /// <param name="usuarioId">ID do usuário.</param>
    /// <returns>Lista de obras do usuário.</returns>
    Task<IEnumerable<Obra>> ObterObrasPorUsuarioAsync(Guid usuarioId);

    /// <summary>
    /// Obtém uma obra pelo código.
    /// </summary>
    /// <param name="codigo">Código da obra.</param>
    /// <returns>Obra encontrada ou null.</returns>
    Task<Obra?> ObterPorCodigoAsync(string codigo);
}
