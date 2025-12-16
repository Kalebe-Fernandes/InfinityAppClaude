using Domain.Entidades.Apontamentos;
using Domain.Entidades.Comum;
using Domain.Entidades.Fichas.Base;

namespace Domain.Entidades.Fichas;

/// <summary>
/// Representa uma ficha de serviço de CBUQ (Concreto Betuminoso Usinado a Quente).
/// </summary>
public class FichaCBUQ : FichaBase
{
    public virtual ICollection<ApontamentoCBUQ> Apontamentos { get; set; } = [];

    public void AdicionarApontamento(ApontamentoCBUQ apontamento)
    {
        if (!PodeSerEditada())
            throw new InvalidOperationException("Não é possível adicionar apontamentos a uma ficha que não está pendente.");

        apontamento.FichaCBUQId = Id;
        Apontamentos.Add(apontamento);
        AtualizarDataAtualizacao();
    }

    public void RemoverUltimoApontamento()
    {
        if (!PodeSerEditada())
            throw new InvalidOperationException("Não é possível remover apontamentos de uma ficha que não está pendente.");

        if (!Apontamentos.Any())
            throw new InvalidOperationException("Não há apontamentos para remover.");

        var ultimoApontamento = Apontamentos.OrderByDescending(a => a.DataCriacao).First();
        Apontamentos.Remove(ultimoApontamento);
        AtualizarDataAtualizacao();
    }

    protected override void ValidarAntesDeFinalizar()
    {
        if (!Apontamentos.Any())
            throw new InvalidOperationException("A ficha deve ter pelo menos um apontamento para ser finalizada.");

        if (Trecho.PistaDupla && !Pista.HasValue)
            throw new InvalidOperationException("Trecho de pista dupla requer seleção de pista.");
    }
}
