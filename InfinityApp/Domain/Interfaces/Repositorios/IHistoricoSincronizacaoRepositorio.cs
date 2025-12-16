using Domain.Entidades.Sincronizacao;

namespace Domain.Interfaces.Repositorios;

/// <summary>
/// Interface para repositório de Histórico de Sincronização.
/// </summary>
public interface IHistoricoSincronizacaoRepositorio : IRepositorio<HistoricoSincronizacao>
{
    /// <summary>
    /// Obtém histórico por período.
    /// </summary>
    Task<IEnumerable<HistoricoSincronizacao>> ObterHistoricoPorPeriodoAsync(
        DateTime dataInicio, 
        DateTime dataFim);

    /// <summary>
    /// Obtém histórico de um usuário específico.
    /// </summary>
    Task<IEnumerable<HistoricoSincronizacao>> ObterHistoricoPorUsuarioAsync(Guid usuarioId);

    /// <summary>
    /// Obtém histórico por tipo de operação (Pull/Push).
    /// </summary>
    Task<IEnumerable<HistoricoSincronizacao>> ObterHistoricoPorTipoAsync(string tipo);

    /// <summary>
    /// Obtém últimas sincronizações.
    /// </summary>
    Task<IEnumerable<HistoricoSincronizacao>> ObterUltimasSincronizacoesAsync(int quantidade);
}
