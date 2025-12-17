using Aplication.DTOs;

namespace Aplication.Servicos.Comum;

/// <summary>
/// Interface para serviço de materiais.
/// </summary>
public interface IServicoMaterial
{
    Task<IEnumerable<MaterialDto>> ObterTodosAsync();
    Task<MaterialDto?> ObterPorIdAsync(Guid id);
}
