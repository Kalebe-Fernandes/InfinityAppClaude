namespace Aplication.DTOs;

/// <summary>
/// DTO para transferência de dados de Depósito.
/// </summary>
public class DepositoDto
{
    /// <summary>
    /// ID do depósito.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Código único do depósito.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descrição do depósito.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Latitude do depósito.
    /// </summary>
    public decimal? Latitude { get; set; }

    /// <summary>
    /// Longitude do depósito.
    /// </summary>
    public decimal? Longitude { get; set; }

    /// <summary>
    /// Indica se é um depósito pré-cadastrado.
    /// </summary>
    public bool Provisorio { get; set; }

    /// <summary>
    /// ID da obra (opcional para provisórios).
    /// </summary>
    public Guid? ObraId { get; set; }
}
