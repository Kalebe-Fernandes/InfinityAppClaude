using Domain.Entidades.Apontamentos;
using Domain.Entidades.Comum;
using Domain.Entidades.Fichas.Base;

namespace Domain.Entidades.Fichas;

/// <summary>
/// Representa uma ficha de serviço de Bota Dentro (escavação e transporte de material).
/// </summary>
public class FichaBotaDentro : FichaBase
{
    public Guid? DepositoOrigemId { get; set; }
    public virtual Deposito? DepositoOrigem { get; set; }

    public Guid? DepositoDestinoId { get; set; }
    public virtual Deposito? DepositoDestino { get; set; }

    public virtual ICollection<ApontamentoBotaDentro> Apontamentos { get; set; } = [];

    public void AdicionarApontamento(ApontamentoBotaDentro apontamento)
    {
        if (!PodeSerEditada())
            throw new InvalidOperationException("Não é possível adicionar apontamentos a uma ficha que não está pendente.");

        apontamento.FichaBotaDentroId = Id;
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

        if (!DepositoOrigemId.HasValue)
            throw new InvalidOperationException("O depósito de origem é obrigatório.");
    }
}
