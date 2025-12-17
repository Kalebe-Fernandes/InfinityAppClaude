using Aplication.DTOs;

namespace Aplication.Servicos.Comum;

/// <summary>
/// Interface para serviço de obras.
/// </summary>
public interface IServicoObra
{
    /// <summary>
    /// Obtém todas as obras.
    /// </summary>
    Task<IEnumerable<ObraDto>> ObterTodasAsync();

    /// <summary>
    /// Obtém todas as obras ativas.
    /// </summary>
    Task<IEnumerable<ObraDto>> ObterTodasAtivasAsync();

    /// <summary>
    /// Obtém uma obra por ID.
    /// </summary>
    Task<ObraDto?> ObterPorIdAsync(Guid id);

    /// <summary>
    /// Obtém uma obra por código.
    /// </summary>
    Task<ObraDto?> ObterPorCodigoAsync(string codigo);

    /// <summary>
    /// Busca obras por termo (nome, código ou número).
    /// </summary>
    Task<IEnumerable<ObraDto>> BuscarAsync(string termo);
}
