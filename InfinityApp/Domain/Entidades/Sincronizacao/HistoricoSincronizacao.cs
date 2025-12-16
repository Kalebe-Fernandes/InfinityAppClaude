using Domain.Entidades.Base;
using Domain.Entidades.Comum;
using Domain.Enums;

namespace Domain.Entidades.Sincronizacao;

/// <summary>
/// Representa um registro no histórico de sincronizações.
/// Mantém log de todas as operações de sincronização (Pull e Push).
/// </summary>
public class HistoricoSincronizacao : EntidadeBase
{
    /// <summary>
    /// Tipo de sincronização (Pull ou Push).
    /// </summary>
    public string Tipo { get; set; } = string.Empty;

    /// <summary>
    /// ID do usuário que realizou a sincronização.
    /// </summary>
    public Guid UsuarioId { get; set; }

    /// <summary>
    /// Navegação: Usuário que realizou a sincronização.
    /// </summary>
    public virtual Usuario Usuario { get; set; } = null!;

    /// <summary>
    /// ID da obra relacionada (opcional, usado em sincronizações específicas).
    /// </summary>
    public Guid? ObraId { get; set; }

    /// <summary>
    /// Navegação: Obra relacionada.
    /// </summary>
    public virtual Obra? Obra { get; set; }

    /// <summary>
    /// Quantidade de fichas processadas.
    /// </summary>
    public int QuantidadeFichas { get; set; }

    /// <summary>
    /// Quantidade de fichas sincronizadas com sucesso.
    /// </summary>
    public int QuantidadeSucesso { get; set; }

    /// <summary>
    /// Quantidade de fichas com erro.
    /// </summary>
    public int QuantidadeErro { get; set; }

    /// <summary>
    /// Status geral da sincronização.
    /// </summary>
    public StatusSincronizacao Status { get; set; }

    /// <summary>
    /// Data e hora de início da sincronização.
    /// </summary>
    public DateTime DataInicio { get; set; }

    /// <summary>
    /// Data e hora de término da sincronização.
    /// </summary>
    public DateTime? DataFim { get; set; }

    /// <summary>
    /// Duração total da sincronização em segundos.
    /// </summary>
    public int? DuracaoSegundos { get; set; }

    /// <summary>
    /// Mensagem ou log detalhado da sincronização.
    /// </summary>
    public string? Detalhes { get; set; }

    /// <summary>
    /// Construtor que inicializa data de início.
    /// </summary>
    public HistoricoSincronizacao()
    {
        DataInicio = DateTime.UtcNow;
        Status = StatusSincronizacao.EmProgresso;
    }

    /// <summary>
    /// Finaliza o histórico de sincronização.
    /// </summary>
    public void Finalizar(int quantidadeFichas, int sucesso, int erros, string detalhes)
    {
        DataFim = DateTime.UtcNow;
        DuracaoSegundos = (int)(DataFim.Value - DataInicio).TotalSeconds;
        QuantidadeFichas = quantidadeFichas;
        QuantidadeSucesso = sucesso;
        QuantidadeErro = erros;
        Detalhes = detalhes;

        if (QuantidadeErro == 0)
            Status = StatusSincronizacao.Sucesso;
        else if (QuantidadeSucesso > 0)
            Status = StatusSincronizacao.Erro; // Parcialmente com erro
        else
            Status = StatusSincronizacao.Erro;

        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Registra o processamento de uma ficha.
    /// </summary>
    public void RegistrarProcessamento(bool sucesso)
    {
        QuantidadeFichas++;
        if (sucesso)
            QuantidadeSucesso++;
        else
            QuantidadeErro++;

        AtualizarDataAtualizacao();
    }
}
