using Domain.Entidades.Comum;

namespace Domain.Interfaces.Repositorios;

/// <summary>
/// Interface para repositório de Serviços.
/// </summary>
public interface IServicoRepositorio : IRepositorio<Servico>
{
    /// <summary>
    /// Obtém todos os serviços ativos.
    /// </summary>
    Task<IEnumerable<Servico>> ObterServicosAtivosAsync();

    /// <summary>
    /// Obtém serviços de uma obra específica.
    /// </summary>
    Task<IEnumerable<Servico>> ObterServicosPorObraAsync(Guid obraId);

    /// <summary>
    /// Obtém um serviço pelo código.
    /// </summary>
    Task<Servico?> ObterPorCodigoAsync(string codigo);
}
