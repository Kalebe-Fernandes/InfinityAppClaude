using Domain.Entidades.Base;
using Domain.Entidades.Comum;

namespace Domain.Entidades.Apontamentos;

/// <summary>
/// Entidade associativa entre ApontamentoCBUQ e Material.
/// </summary>
public class ApontamentoCBUQMaterial : EntidadeBase
{
    public Guid ApontamentoCBUQId { get; set; }
    public virtual ApontamentoCBUQ ApontamentoCBUQ { get; set; } = null!;

    public Guid MaterialId { get; set; }
    public virtual Material Material { get; set; } = null!;

    public decimal Quantidade { get; set; }
}
