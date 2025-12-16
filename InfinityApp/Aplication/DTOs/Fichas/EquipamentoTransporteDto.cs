namespace Aplication.DTOs.Fichas;

/// <summary>
/// DTO para Equipamento de Transporte da ficha.
/// </summary>
public class EquipamentoTransporteDto
{
    /// <summary>
    /// ID do equipamento.
    /// </summary>
    public Guid EquipamentoId { get; set; }

    /// <summary>
    /// Descrição do equipamento.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Placa do equipamento.
    /// </summary>
    public string? Placa { get; set; }

    /// <summary>
    /// Capacidade do equipamento em m³.
    /// </summary>
    public decimal? Capacidade { get; set; }
}
