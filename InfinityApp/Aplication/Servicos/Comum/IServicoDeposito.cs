using Aplication.DTOs;

namespace Aplication.Servicos.Comum;

/// <summary>
/// Interface para serviço de depósitos.
/// </summary>
public interface IServicoDeposito
{
    Task<IEnumerable<DepositoDto>> ObterTodosAsync();
    Task<DepositoDto?> ObterPorIdAsync(Guid id);
}
