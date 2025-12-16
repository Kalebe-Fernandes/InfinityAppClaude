namespace Aplication.DTOs.Fichas;

public class ApontamentoCBUQDto
{
    public Guid Id { get; set; }
    public string Lado { get; set; } = string.Empty;
    public int EstacaInicial { get; set; }
    public decimal FracaoInicial { get; set; }
    public int EstacaFinal { get; set; }
    public decimal FracaoFinal { get; set; }
    public decimal Extensao { get; set; }
    public decimal Largura { get; set; }
    public decimal EspessuraCm { get; set; }
    public decimal AreaM2 { get; set; }
    public decimal VolumeM3 { get; set; }
    public List<MaterialQuantidadeDto> Materiais { get; set; } = [];
}
