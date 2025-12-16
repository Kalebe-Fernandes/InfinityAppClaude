using Domain.Entidades.Base;
using Domain.Entidades.Comum;
using Domain.Entidades.Fichas;

namespace Domain.Entidades.Sincronizacao;

/// <summary>
/// Entidade associativa entre FichaViagemCB e Equipamento.
/// Representa um equipamento de transporte utilizado em uma ficha de viagem.
/// </summary>
public class FichaEquipamento : EntidadeBase
{
    /// <summary>
    /// ID da ficha de viagem.
    /// </summary>
    public Guid FichaViagemCBId { get; set; }

    /// <summary>
    /// Navegação: Ficha de viagem.
    /// </summary>
    public virtual FichaViagemCB FichaViagemCB { get; set; } = null!;

    /// <summary>
    /// ID do equipamento de transporte.
    /// </summary>
    public Guid EquipamentoId { get; set; }

    /// <summary>
    /// Navegação: Equipamento de transporte.
    /// </summary>
    public virtual Equipamento Equipamento { get; set; } = null!;
}
