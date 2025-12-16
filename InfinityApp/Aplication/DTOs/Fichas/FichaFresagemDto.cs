namespace Aplication.DTOs.Fichas;

/// <summary>
/// DTO para Ficha de Fresagem.
/// </summary>
public class FichaFresagemDto : FichaBaseDto
{
    public List<ApontamentoFresagemDto> Apontamentos { get; set; } = [];
    public decimal ExtensaoTotal { get; set; }
    public decimal LarguraMedia { get; set; }
    public decimal AreaTotal { get; set; }
    public decimal VolumeTotal { get; set; }
}
