using Domain.Entidades.Comum;
using Domain.Enums;

namespace Domain.Interfaces.Repositorios;

/// <summary>
/// Interface para repositório de Equipamentos.
/// </summary>
public interface IEquipamentoRepositorio : IRepositorio<Equipamento>
{
    /// <summary>
    /// Obtém equipamentos de uma obra específica.
    /// </summary>
    Task<IEnumerable<Equipamento>> ObterEquipamentosPorObraAsync(Guid obraId);

    /// <summary>
    /// Obtém equipamentos por tipo.
    /// </summary>
    Task<IEnumerable<Equipamento>> ObterEquipamentosPorTipoAsync(TipoEquipamento tipo, Guid obraId);

    /// <summary>
    /// Obtém equipamentos pré-cadastrados (provisórios).
    /// </summary>
    Task<IEnumerable<Equipamento>> ObterEquipamentosProvisorioAsync();

    /// <summary>
    /// Obtém um equipamento pela placa.
    /// </summary>
    Task<Equipamento?> ObterPorPlacaAsync(string placa);
}
