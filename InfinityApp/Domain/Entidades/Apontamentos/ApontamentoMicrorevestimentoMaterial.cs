using Domain.Entidades.Base;
using Domain.Entidades.Comum;

namespace Domain.Entidades.Apontamentos;

/// <summary>
/// Entidade associativa entre ApontamentoMicrorevestimento e Material.
/// </summary>
public class ApontamentoMicrorevestimentoMaterial : EntidadeBase
{
    public Guid ApontamentoMicrorevestimentoId { get; set; }
    public virtual ApontamentoMicrorevestimento ApontamentoMicrorevestimento { get; set; } = null!;

    public Guid MaterialId { get; set; }
    public virtual Material Material { get; set; } = null!;

    public decimal Quantidade { get; set; }
}
