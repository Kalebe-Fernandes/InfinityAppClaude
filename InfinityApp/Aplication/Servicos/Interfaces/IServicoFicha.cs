using Aplication.DTOs.Fichas;

namespace Aplication.Servicos.Interfaces;

/// <summary>
/// Interface genérica para serviços de fichas.
/// Define operações comuns a todos os tipos de fichas.
/// </summary>
/// <typeparam name="TFichaDto">Tipo do DTO da ficha.</typeparam>
public interface IServicoFicha<TFichaDto> where TFichaDto : FichaBaseDto
{
    /// <summary>
    /// Cria uma nova ficha.
    /// </summary>
    Task<TFichaDto> CriarAsync(TFichaDto fichaDto);

    /// <summary>
    /// Atualiza uma ficha existente.
    /// </summary>
    Task<TFichaDto> AtualizarAsync(TFichaDto fichaDto);

    /// <summary>
    /// Obtém uma ficha por ID.
    /// </summary>
    Task<TFichaDto?> ObterPorIdAsync(Guid id);

    /// <summary>
    /// Obtém todas as fichas de uma obra.
    /// </summary>
    Task<IEnumerable<TFichaDto>> ObterPorObraAsync(Guid obraId);

    /// <summary>
    /// Obtém fichas por status.
    /// </summary>
    Task<IEnumerable<TFichaDto>> ObterPorStatusAsync(string status, Guid? obraId = null);

    /// <summary>
    /// Finaliza uma ficha (muda status para Finalizada).
    /// </summary>
    Task<bool> FinalizarAsync(Guid fichaId);

    /// <summary>
    /// Desfinaliza uma ficha (volta status para Pendente).
    /// </summary>
    Task<bool> DesfinalizarAsync(Guid fichaId);

    /// <summary>
    /// Cancela uma ficha.
    /// </summary>
    Task<bool> CancelarAsync(Guid fichaId);

    /// <summary>
    /// Exclui uma ficha.
    /// </summary>
    Task<bool> ExcluirAsync(Guid fichaId);

    /// <summary>
    /// Obtém o próximo número de ficha para uma obra.
    /// </summary>
    Task<int> ObterProximoNumeroFichaAsync(Guid obraId);
}
