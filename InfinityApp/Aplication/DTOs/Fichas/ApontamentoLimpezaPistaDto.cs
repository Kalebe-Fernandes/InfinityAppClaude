namespace Aplication.DTOs.Fichas;

/// <summary>
/// DTO para Apontamento de Limpeza de Pista.
/// </summary>
public class ApontamentoLimpezaPistaDto
{
    /// <summary>
    /// ID do apontamento.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Lado da pista (LD, LE, LD_LE, CC).
    /// </summary>
    public string Lado { get; set; } = string.Empty;

    /// <summary>
    /// Estaca inicial (número inteiro).
    /// </summary>
    public int EstacaInicial { get; set; }

    /// <summary>
    /// Fração da estaca inicial.
    /// </summary>
    public decimal FracaoInicial { get; set; }

    /// <summary>
    /// Estaca final (número inteiro).
    /// </summary>
    public int EstacaFinal { get; set; }

    /// <summary>
    /// Fração da estaca final.
    /// </summary>
    public decimal FracaoFinal { get; set; }

    /// <summary>
    /// Extensão em metros.
    /// </summary>
    public decimal Extensao { get; set; }

    /// <summary>
    /// Largura em metros.
    /// </summary>
    public decimal Largura { get; set; }

    /// <summary>
    /// Área em m².
    /// </summary>
    public decimal AreaM2 { get; set; }
}
