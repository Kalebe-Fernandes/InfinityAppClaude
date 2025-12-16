namespace Aplication.DTOs.Fichas;

public class MaterialQuantidadeDto
{
    public Guid MaterialId { get; set; }
    public string? MaterialDescricao { get; set; }
    public decimal Quantidade { get; set; }
}
