namespace Aplication.DTOs;

/// <summary>
/// DTO para transferência de dados de Trecho.
/// </summary>
public class TrechoDto
{
    /// <summary>
    /// ID do trecho.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Código único do trecho.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descrição do trecho.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Tipo de referência (Estaca ou Quilometro).
    /// </summary>
    public string Tipo { get; set; } = string.Empty;

    /// <summary>
    /// Indica se o trecho possui pista dupla.
    /// </summary>
    public bool PistaDupla { get; set; }

    /// <summary>
    /// Estaca ou KM inicial.
    /// </summary>
    public decimal? EstacaInicial { get; set; }

    /// <summary>
    /// Estaca ou KM final.
    /// </summary>
    public decimal? EstacaFinal { get; set; }

    /// <summary>
    /// ID da obra à qual o trecho pertence.
    /// </summary>
    public Guid ObraId { get; set; }
}
