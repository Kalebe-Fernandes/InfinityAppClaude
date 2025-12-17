namespace Aplication.DTOs;

/// <summary>
/// DTO para transferência de dados de Equipamento.
/// </summary>
public class EquipamentoDto
{
    /// <summary>
    /// ID do equipamento.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Código único do equipamento.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descrição do equipamento.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Tipo do equipamento (Execucao, Transporte, Ambos).
    /// </summary>
    public string Tipo { get; set; } = string.Empty;

    /// <summary>
    /// Capacidade do equipamento em m³.
    /// </summary>
    public decimal? Capacidade { get; set; }

    /// <summary>
    /// Placa do equipamento.
    /// </summary>
    public string? Placa { get; set; }

    /// <summary>
    /// Indica se é um equipamento pré-cadastrado.
    /// </summary>
    public bool Provisorio { get; set; }

    /// <summary>
    /// ID da obra (opcional para provisórios).
    /// </summary>
    public Guid? ObraId { get; set; }

    public string? Prefixo { get; set; }
}
