using Domain.Entidades.Base;
using Domain.Entidades.Comum;
using Domain.Entidades.Fichas;

namespace Domain.Entidades.Apontamentos;

/// <summary>
/// Representa um apontamento de Viagens de CB (por equipamento e material).
/// </summary>
public class ApontamentoViagemCB : EntidadeBase
{
    public Guid FichaViagemCBId { get; set; }
    public virtual FichaViagemCB FichaViagemCB { get; set; } = null!;

    public Guid EquipamentoId { get; set; }
    public virtual Equipamento Equipamento { get; set; } = null!;

    public Guid MaterialId { get; set; }
    public virtual Material Material { get; set; } = null!;

    public TimeSpan? HoraCarregamento { get; set; }
    public TimeSpan? HoraDescarregamento { get; set; }
    public int QtdViagens { get; set; }
    public decimal VolumeM3 { get; set; }

    public void Validar()
    {
        if (QtdViagens <= 0)
            throw new InvalidOperationException("A quantidade de viagens deve ser maior que zero.");

        if (VolumeM3 <= 0)
            throw new InvalidOperationException("O volume deve ser maior que zero.");

        if (HoraCarregamento.HasValue && HoraDescarregamento.HasValue)
        {
            if (HoraCarregamento >= HoraDescarregamento)
                throw new InvalidOperationException("A hora de carregamento deve ser anterior à hora de descarregamento.");
        }
    }
}
