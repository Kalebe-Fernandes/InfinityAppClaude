namespace Aplication.DTOs.Fichas;

/// <summary>
/// DTO para Ficha de CBUQ.
/// </summary>
public class FichaCBUQDto : FichaBaseDto
{
    public List<ApontamentoCBUQDto> Apontamentos { get; set; } = [];
    public decimal ExtensaoTotal { get; set; }
    public decimal LarguraMedia { get; set; }
    public decimal AreaTotal { get; set; }
    public decimal VolumeTotal { get; set; }
}
