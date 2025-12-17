using Aplication.DTOs;

namespace Aplication.Servicos.Comum;

/// <summary>
/// Interface para serviço de serviços de obras.
/// </summary>
public interface IServicoServico
{
    Task<IEnumerable<ServicoDto>> ObterTodosAsync();
    Task<IEnumerable<ServicoDto>> ObterPorObraAsync(Guid obraId);
    Task<ServicoDto?> ObterPorIdAsync(Guid id);
}
