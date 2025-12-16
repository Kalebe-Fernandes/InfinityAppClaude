using Domain.Entidades.Apontamentos;
using Domain.Entidades.Comum;
using Domain.Entidades.Fichas.Base;
using Domain.Entidades.Sincronizacao;

namespace Domain.Entidades.Fichas;

/// <summary>
/// Representa uma ficha de serviço de Viagens de CB (Transporte de Materiais).
/// Suporta até 8 equipamentos de transporte com apontamentos por equipamento e material.
/// </summary>
public class FichaViagemCB : FichaBase
{
    /// <summary>
    /// Capacidade padrão dos equipamentos (em m³).
    /// </summary>
    public decimal Capacidade { get; set; }

    /// <summary>
    /// ID do depósito de origem do material.
    /// </summary>
    public Guid? DepositoOrigemId { get; set; }

    /// <summary>
    /// Navegação: Depósito de origem.
    /// </summary>
    public virtual Deposito? DepositoOrigem { get; set; }

    /// <summary>
    /// ID do depósito de destino do material (opcional).
    /// </summary>
    public Guid? DepositoDestinoId { get; set; }

    /// <summary>
    /// Navegação: Depósito de destino.
    /// </summary>
    public virtual Deposito? DepositoDestino { get; set; }

    /// <summary>
    /// Navegação: Equipamentos de transporte utilizados nesta ficha (máximo 8).
    /// </summary>
    public virtual ICollection<FichaEquipamento> Equipamentos { get; set; } = [];

    /// <summary>
    /// Navegação: Apontamentos de viagens desta ficha.
    /// </summary>
    public virtual ICollection<ApontamentoViagemCB> Apontamentos { get; set; } = [];

    private const int MaximoEquipamentos = 8;

    /// <summary>
    /// Adiciona um equipamento de transporte à ficha.
    /// </summary>
    /// <param name="equipamentoId">ID do equipamento a ser adicionado.</param>
    /// <exception cref="InvalidOperationException">Lançada se exceder o limite de equipamentos ou a ficha não puder ser editada.</exception>
    public void AdicionarEquipamento(Guid equipamentoId)
    {
        if (!PodeSerEditada())
            throw new InvalidOperationException("Não é possível adicionar equipamentos a uma ficha que não está pendente.");

        if (Equipamentos.Count >= MaximoEquipamentos)
            throw new InvalidOperationException($"A ficha pode ter no máximo {MaximoEquipamentos} equipamentos de transporte.");

        if (Equipamentos.Any(e => e.EquipamentoId == equipamentoId))
            throw new InvalidOperationException("Este equipamento já foi adicionado à ficha.");

        var fichaEquipamento = new FichaEquipamento
        {
            FichaViagemCBId = Id,
            EquipamentoId = equipamentoId
        };

        Equipamentos.Add(fichaEquipamento);
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Troca um equipamento por outro.
    /// </summary>
    /// <param name="equipamentoAntigoId">ID do equipamento a ser substituído.</param>
    /// <param name="equipamentoNovoId">ID do novo equipamento.</param>
    /// <exception cref="InvalidOperationException">Lançada se a ficha não puder ser editada ou o equipamento não existir.</exception>
    public void TrocarEquipamento(Guid equipamentoAntigoId, Guid equipamentoNovoId)
    {
        if (!PodeSerEditada())
            throw new InvalidOperationException("Não é possível trocar equipamentos de uma ficha que não está pendente.");

        var fichaEquipamento = Equipamentos.FirstOrDefault(e => e.EquipamentoId == equipamentoAntigoId);
        
        if (fichaEquipamento == null)
            throw new InvalidOperationException("Equipamento não encontrado na ficha.");

        if (Equipamentos.Any(e => e.EquipamentoId == equipamentoNovoId))
            throw new InvalidOperationException("O novo equipamento já está na ficha.");

        // Remove apontamentos do equipamento antigo
        var apontamentosAntigos = Apontamentos.Where(a => a.EquipamentoId == equipamentoAntigoId).ToList();
        foreach (var apontamento in apontamentosAntigos)
        {
            Apontamentos.Remove(apontamento);
        }

        fichaEquipamento.EquipamentoId = equipamentoNovoId;
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Adiciona um novo apontamento à ficha.
    /// </summary>
    /// <param name="apontamento">Apontamento a ser adicionado.</param>
    /// <exception cref="InvalidOperationException">Lançada se a ficha não puder ser editada ou equipamento não estiver na ficha.</exception>
    public void AdicionarApontamento(ApontamentoViagemCB apontamento)
    {
        if (!PodeSerEditada())
            throw new InvalidOperationException("Não é possível adicionar apontamentos a uma ficha que não está pendente.");

        if (!Equipamentos.Any(e => e.EquipamentoId == apontamento.EquipamentoId))
            throw new InvalidOperationException("O equipamento do apontamento não está associado a esta ficha.");

        apontamento.FichaViagemCBId = Id;
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
        if (!Equipamentos.Any())
            throw new InvalidOperationException("A ficha deve ter pelo menos um equipamento de transporte.");

        if (!Apontamentos.Any())
            throw new InvalidOperationException("A ficha deve ter pelo menos um apontamento para ser finalizada.");

        if (!DepositoOrigemId.HasValue)
            throw new InvalidOperationException("O depósito de origem é obrigatório.");
    }
}