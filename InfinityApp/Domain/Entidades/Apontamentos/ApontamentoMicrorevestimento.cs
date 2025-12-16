using Domain.Entidades.Base;
using Domain.Entidades.Fichas;
using Domain.Enums;
using Domain.ObjetosDeValor;

namespace Domain.Entidades.Apontamentos;

/// <summary>
/// Representa um apontamento de Microrevestimento (por área com materiais).
/// </summary>
public class ApontamentoMicrorevestimento : EntidadeBase
{
    public Guid FichaMicrorevestimentoId { get; set; }
    public virtual FichaMicrorevestimento FichaMicrorevestimento { get; set; } = null!;

    public Lado Lado { get; set; }
    public int EstacaInicial { get; set; }
    public decimal FracaoInicial { get; set; }
    public int EstacaFinal { get; set; }
    public decimal FracaoFinal { get; set; }
    public decimal Extensao { get; set; }
    public decimal Largura { get; set; }
    public decimal EspessuraCm { get; set; }
    public decimal AreaM2 { get; set; }
    public decimal VolumeM3 { get; set; }

    public virtual ICollection<ApontamentoMicrorevestimentoMaterial> Materiais { get; set; } = new List<ApontamentoMicrorevestimentoMaterial>();

    public void Validar()
    {
        var estacaIni = Estaca.Criar(EstacaInicial, FracaoInicial);
        var estacaFim = Estaca.Criar(EstacaFinal, FracaoFinal);

        if (estacaIni >= estacaFim)
            throw new InvalidOperationException("A estaca inicial deve ser menor que a estaca final.");

        if (Largura <= 0)
            throw new InvalidOperationException("A largura deve ser maior que zero.");

        if (EspessuraCm <= 0)
            throw new InvalidOperationException("A espessura deve ser maior que zero.");
    }
}
