using Domain.Entidades.Comum;

namespace Domain.Interfaces.Repositorios;

/// <summary>
/// Interface para repositório de Materiais.
/// </summary>
public interface IMaterialRepositorio : IRepositorio<Material>
{
    /// <summary>
    /// Obtém materiais associados a um serviço.
    /// </summary>
    Task<IEnumerable<Material>> ObterMateriaisPorServicoAsync(Guid servicoId);

    /// <summary>
    /// Obtém um material pelo código.
    /// </summary>
    Task<Material?> ObterPorCodigoAsync(string codigo);
}
