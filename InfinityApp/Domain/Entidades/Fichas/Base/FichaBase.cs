using Domain.Entidades.Base;
using Domain.Entidades.Comum;
using Domain.Enums;

namespace Domain.Entidades.Fichas.Base;

/// <summary>
/// Classe base abstrata para todas as fichas de serviço.
/// Contém propriedades comuns a todos os tipos de fichas.
/// </summary>
public abstract class FichaBase : EntidadeBase
{
    /// <summary>
    /// Número sequencial da ficha dentro da obra.
    /// </summary>
    public int Numero { get; set; }

    /// <summary>
    /// Data de produção/execução do serviço.
    /// </summary>
    public DateTime DataProducao { get; set; }

    /// <summary>
    /// ID da obra à qual a ficha pertence.
    /// </summary>
    public Guid ObraId { get; set; }

    /// <summary>
    /// Navegação: Obra à qual a ficha pertence.
    /// </summary>
    public Obra Obra { get; set; } = null!;

    /// <summary>
    /// ID do serviço executado.
    /// </summary>
    public Guid ServicoId { get; set; }

    /// <summary>
    /// Navegação: Serviço executado.
    /// </summary>
    public Servico Servico { get; set; } = null!;

    /// <summary>
    /// ID do trecho onde o serviço foi executado.
    /// </summary>
    public Guid TrechoId { get; set; }

    /// <summary>
    /// Navegação: Trecho onde o serviço foi executado.
    /// </summary>
    public Trecho Trecho { get; set; } = null!;

    /// <summary>
    /// Pista onde o serviço foi executado (obrigatório apenas se trecho for pista dupla).
    /// </summary>
    public Pista? Pista { get; set; }

    /// <summary>
    /// ID do equipamento de execução utilizado.
    /// </summary>
    public Guid EquipamentoExecucaoId { get; set; }

    /// <summary>
    /// Navegação: Equipamento de execução utilizado.
    /// </summary>
    public Equipamento EquipamentoExecucao { get; set; } = null!;

    /// <summary>
    /// Observações gerais sobre a execução do serviço.
    /// </summary>
    public string? Observacoes { get; set; }

    /// <summary>
    /// Status atual da ficha.
    /// </summary>
    public StatusFicha Status { get; set; }

    /// <summary>
    /// Construtor protegido para inicializar com Status Pendente.
    /// </summary>
    protected FichaBase()
    {
        Status = StatusFicha.Pendente;
        DataProducao = DateTime.Today;
    }

    /// <summary>
    /// Finaliza a ficha, mudando o status para Finalizada.
    /// </summary>
    /// <exception cref="InvalidOperationException">Lançada se a ficha não estiver em status Pendente.</exception>
    public virtual void Finalizar()
    {
        if (Status != StatusFicha.Pendente)
            throw new InvalidOperationException("Apenas fichas pendentes podem ser finalizadas.");

        ValidarAntesDeFinalizar();

        Status = StatusFicha.Finalizada;
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Desfinaliza a ficha, voltando o status para Pendente.
    /// </summary>
    /// <exception cref="InvalidOperationException">Lançada se a ficha não estiver finalizada ou já sincronizada.</exception>
    public virtual void Desfinalizar()
    {
        if (Status == StatusFicha.Sincronizada)
            throw new InvalidOperationException("Fichas sincronizadas não podem ser desfinalizadas.");

        if (Status == StatusFicha.Cancelada)
            throw new InvalidOperationException("Fichas canceladas não podem ser desfinalizadas.");

        if (Status != StatusFicha.Finalizada)
            throw new InvalidOperationException("Apenas fichas finalizadas podem ser desfinalizadas.");

        Status = StatusFicha.Pendente;
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Cancela a ficha.
    /// </summary>
    /// <exception cref="InvalidOperationException">Lançada se a ficha já estiver sincronizada.</exception>
    public virtual void Cancelar()
    {
        if (Status == StatusFicha.Sincronizada)
            throw new InvalidOperationException("Fichas sincronizadas não podem ser canceladas.");

        Status = StatusFicha.Cancelada;
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Marca a ficha como sincronizada.
    /// </summary>
    /// <exception cref="InvalidOperationException">Lançada se a ficha não estiver finalizada.</exception>
    public virtual void MarcarComoSincronizada()
    {
        if (Status != StatusFicha.Finalizada)
            throw new InvalidOperationException("Apenas fichas finalizadas podem ser marcadas como sincronizadas.");

        Status = StatusFicha.Sincronizada;
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Verifica se a ficha pode ser editada.
    /// </summary>
    public bool PodeSerEditada()
    {
        return Status == StatusFicha.Pendente;
    }

    /// <summary>
    /// Verifica se a ficha pode ser excluída.
    /// </summary>
    public bool PodeSerExcluida()
    {
        return Status == StatusFicha.Pendente || Status == StatusFicha.Cancelada;
    }

    /// <summary>
    /// Método abstrato para validação específica antes de finalizar.
    /// Deve ser implementado pelas classes filhas.
    /// </summary>
    protected abstract void ValidarAntesDeFinalizar();
}
