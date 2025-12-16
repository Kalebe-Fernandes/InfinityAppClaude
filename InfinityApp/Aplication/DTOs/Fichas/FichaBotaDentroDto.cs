namespace Aplication.DTOs.Fichas;

/// <summary>
/// DTO para Ficha de Bota Dentro.
/// </summary>
public class FichaBotaDentroDto : FichaBaseDto
{
    public Guid? DepositoOrigemId { get; set; }
    public string? DepositoOrigemDescricao { get; set; }
    public Guid? DepositoDestinoId { get; set; }
    public string? DepositoDestinoDescricao { get; set; }
    public List<ApontamentoBotaDentroDto> Apontamentos { get; set; } = new();
    public decimal VolumeTotal { get; set; }
    public int QuantidadeTotalViagens { get; set; }
}
