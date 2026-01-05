using Domain.Entidades.Base;
using Domain.Entidades.Comum;
using Domain.Entidades.Fichas;

namespace Domain.Entidades.Apontamentos;

/// <summary>
/// Representa um apontamento de Bota Dentro (por material).
/// </summary>
public class ApontamentoBotaDentro : EntidadeBase
{
    public Guid FichaBotaDentroId { get; set; }
    public FichaBotaDentro FichaBotaDentro { get; set; } = null!;

    public Guid MaterialId { get; set; }
    public Material Material { get; set; } = null!;

    public int QtdViagens { get; set; }
    public decimal VolumeM3 { get; set; }

    public void Validar()
    {
        if (QtdViagens <= 0)
            throw new InvalidOperationException("A quantidade de viagens deve ser maior que zero.");

        if (VolumeM3 <= 0)
            throw new InvalidOperationException("O volume deve ser maior que zero.");
    }
}
