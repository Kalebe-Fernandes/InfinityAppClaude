namespace Aplication.DTOs.Fichas;

public class ApontamentoBotaDentroDto
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public string? MaterialDescricao { get; set; }
    public int QtdViagens { get; set; }
    public decimal VolumeM3 { get; set; }
}
