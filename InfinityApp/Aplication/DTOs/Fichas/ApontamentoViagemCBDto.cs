namespace Aplication.DTOs.Fichas;

/// <summary>
/// DTO para Apontamento de Viagens de CB.
/// </summary>
public class ApontamentoViagemCBDto
{
    /// <summary>
    /// ID do apontamento.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ID do equipamento de transporte.
    /// </summary>
    public Guid EquipamentoId { get; set; }

    /// <summary>
    /// Descrição do equipamento (para exibição).
    /// </summary>
    public string? EquipamentoDescricao { get; set; }

    /// <summary>
    /// ID do material transportado.
    /// </summary>
    public Guid MaterialId { get; set; }

    /// <summary>
    /// Descrição do material (para exibição).
    /// </summary>
    public string? MaterialDescricao { get; set; }

    /// <summary>
    /// Hora de carregamento.
    /// </summary>
    public TimeSpan? HoraCarregamento { get; set; }

    /// <summary>
    /// Hora de descarregamento.
    /// </summary>
    public TimeSpan? HoraDescarregamento { get; set; }

    /// <summary>
    /// Quantidade de viagens.
    /// </summary>
    public int QtdViagens { get; set; }

    /// <summary>
    /// Volume total em m³.
    /// </summary>
    public decimal VolumeM3 { get; set; }
}
