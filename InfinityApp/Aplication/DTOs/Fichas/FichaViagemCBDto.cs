namespace Aplication.DTOs.Fichas;

/// <summary>
/// DTO para Ficha de Viagens de CB.
/// </summary>
public class FichaViagemCBDto : FichaBaseDto
{
    /// <summary>
    /// Capacidade padrão dos equipamentos em m³.
    /// </summary>
    public decimal Capacidade { get; set; }

    /// <summary>
    /// ID do depósito de origem.
    /// </summary>
    public Guid? DepositoOrigemId { get; set; }

    /// <summary>
    /// Descrição do depósito de origem (para exibição).
    /// </summary>
    public string? DepositoOrigemDescricao { get; set; }

    /// <summary>
    /// ID do depósito de destino.
    /// </summary>
    public Guid? DepositoDestinoId { get; set; }

    /// <summary>
    /// Descrição do depósito de destino (para exibição).
    /// </summary>
    public string? DepositoDestinoDescricao { get; set; }

    /// <summary>
    /// Lista de equipamentos de transporte utilizados (máximo 8).
    /// </summary>
    public List<EquipamentoTransporteDto> Equipamentos { get; set; } = [];

    /// <summary>
    /// Lista de apontamentos da ficha.
    /// </summary>
    public List<ApontamentoViagemCBDto> Apontamentos { get; set; } = [];

    /// <summary>
    /// Volume total transportado em m³ (soma dos apontamentos).
    /// </summary>
    public decimal VolumeTotal { get; set; }

    /// <summary>
    /// Quantidade total de viagens (soma dos apontamentos).
    /// </summary>
    public int QuantidadeTotalViagens { get; set; }
}