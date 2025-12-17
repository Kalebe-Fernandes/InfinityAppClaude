using Aplication.DTOs;

namespace Aplication.Servicos.Comum;

/// <summary>
/// Interface para serviço de equipamentos.
/// </summary>
public interface IServicoEquipamento
{
    Task<IEnumerable<EquipamentoDto>> ObterTodosAsync();
    Task<IEnumerable<EquipamentoDto>> ObterPorTipoAsync(string tipo);
    Task<EquipamentoDto?> ObterPorIdAsync(Guid id);
}
