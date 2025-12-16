using Domain.Entidades.Comum;

namespace Domain.Interfaces.Repositorios;

/// <summary>
/// Interface para repositório de Trechos.
/// </summary>
public interface ITrechoRepositorio : IRepositorio<Trecho>
{
    /// <summary>
    /// Obtém trechos de uma obra específica.
    /// </summary>
    Task<IEnumerable<Trecho>> ObterTrechosPorObraAsync(Guid obraId);

    /// <summary>
    /// Obtém um trecho pelo código.
    /// </summary>
    Task<Trecho?> ObterPorCodigoAsync(string codigo);

    /// <summary>
    /// Obtém trechos de pista dupla.
    /// </summary>
    Task<IEnumerable<Trecho>> ObterTrechosPistaDuplaAsync(Guid obraId);
}
