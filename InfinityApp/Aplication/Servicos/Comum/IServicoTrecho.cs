using Aplication.DTOs;

namespace Aplication.Servicos.Comum;

/// <summary>
/// Interface para serviço de trechos.
/// </summary>
public interface IServicoTrecho
{
    Task<IEnumerable<TrechoDto>> ObterTodosAsync();
    Task<IEnumerable<TrechoDto>> ObterPorObraAsync(Guid obraId);
    Task<TrechoDto?> ObterPorIdAsync(Guid id);
}
