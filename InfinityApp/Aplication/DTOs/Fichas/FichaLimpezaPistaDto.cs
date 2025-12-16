namespace Aplication.DTOs.Fichas;

/// <summary>
/// DTO para Ficha de Limpeza de Pista.
/// </summary>
public class FichaLimpezaPistaDto : FichaBaseDto
{
    /// <summary>
    /// Lista de apontamentos da ficha.
    /// </summary>
    public List<ApontamentoLimpezaPistaDto> Apontamentos { get; set; } = [];

    /// <summary>
    /// Extensão total calculada (soma dos apontamentos).
    /// </summary>
    public decimal ExtensaoTotal { get; set; }

    /// <summary>
    /// Largura média calculada.
    /// </summary>
    public decimal LarguraMedia { get; set; }

    /// <summary>
    /// Área total em m² (soma dos apontamentos).
    /// </summary>
    public decimal AreaTotal { get; set; }
}