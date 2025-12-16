namespace Domain.Enums;

/// <summary>
/// Representa o tipo de equipamento utilizado nos serviços.
/// </summary>
public enum TipoEquipamento
{
    /// <summary>
    /// Equipamento de execução do serviço (ex: Motoniveladora, Escavadeira).
    /// </summary>
    Execucao = 0,

    /// <summary>
    /// Equipamento de transporte de materiais (ex: Caminhão Basculante).
    /// </summary>
    Transporte = 1,

    /// <summary>
    /// Equipamento que pode ser usado tanto para execução quanto transporte.
    /// </summary>
    Ambos = 2
}
