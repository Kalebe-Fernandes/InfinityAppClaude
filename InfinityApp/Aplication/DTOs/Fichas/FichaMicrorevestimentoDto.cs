namespace Aplication.DTOs.Fichas;

/// <summary>
/// DTO para Ficha de Microrevestimento.
/// </summary>
public class FichaMicrorevestimentoDto : FichaBaseDto
{
    public List<ApontamentoMicrorevestimentoDto> Apontamentos { get; set; } = [];
    public decimal ExtensaoTotal { get; set; }
    public decimal LarguraMedia { get; set; }
    public decimal AreaTotal { get; set; }
    public decimal VolumeTotal { get; set; }
}
