using Domain.Entidades.Apontamentos;
using Domain.Entidades.Fichas.Base;

namespace Domain.Entidades.Fichas;

/// <summary>
/// Representa uma ficha de serviço de Limpeza de Pista.
/// Registra apontamentos de limpeza por área (lado, estacas, largura).
/// </summary>
public class FichaLimpezaPista : FichaBase
{
    /// <summary>
    /// Navegação: Apontamentos de limpeza desta ficha.
    /// </summary>
    public virtual ICollection<ApontamentoLimpezaPista> Apontamentos { get; set; } = [];

    /// <summary>
    /// Adiciona um novo apontamento à ficha.
    /// </summary>
    /// <param name="apontamento">Apontamento a ser adicionado.</param>
    /// <exception cref="InvalidOperationException">Lançada se a ficha não puder ser editada.</exception>
    public void AdicionarApontamento(ApontamentoLimpezaPista apontamento)
    {
        if (!PodeSerEditada())
            throw new InvalidOperationException("Não é possível adicionar apontamentos a uma ficha que não está pendente.");

        apontamento.FichaLimpezaPistaId = Id;
        Apontamentos.Add(apontamento);
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Remove o último apontamento da ficha.
    /// </summary>
    /// <exception cref="InvalidOperationException">Lançada se não houver apontamentos ou a ficha não puder ser editada.</exception>
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

    /// <summary>
    /// Valida a ficha antes de finalizar.
    /// </summary>
    protected override void ValidarAntesDeFinalizar()
    {
        if (!Apontamentos.Any())
            throw new InvalidOperationException("A ficha deve ter pelo menos um apontamento para ser finalizada.");

        if (Trecho.PistaDupla && !Pista.HasValue)
            throw new InvalidOperationException("Trecho de pista dupla requer seleção de pista.");
    }
}
