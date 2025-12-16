using Domain.Entidades.Fichas.Base;
using Domain.Enums;

namespace Domain.Interfaces.Repositorios;

/// <summary>
/// Interface genérica para repositórios de fichas.
/// </summary>
/// <typeparam name="TFicha">Tipo da ficha que herda de FichaBase.</typeparam>
public interface IFichaRepositorio<TFicha> : IRepositorio<TFicha> where TFicha : FichaBase
{
    /// <summary>
    /// Obtém fichas de uma obra específica.
    /// </summary>
    Task<IEnumerable<TFicha>> ObterFichasPorObraAsync(Guid obraId);

    /// <summary>
    /// Obtém fichas por status.
    /// </summary>
    Task<IEnumerable<TFicha>> ObterFichasPorStatusAsync(StatusFicha status, Guid? obraId = null);

    /// <summary>
    /// Obtém fichas finalizadas pendentes de sincronização.
    /// </summary>
    Task<IEnumerable<TFicha>> ObterFichasPendentesSincronizacaoAsync(Guid? obraId = null);

    /// <summary>
    /// Obtém fichas por período.
    /// </summary>
    Task<IEnumerable<TFicha>> ObterFichasPorPeriodoAsync(DateTime dataInicio, DateTime dataFim, Guid? obraId = null);

    /// <summary>
    /// Obtém o último número de ficha de uma obra.
    /// </summary>
    Task<int> ObterUltimoNumeroFichaAsync(Guid obraId);
}
