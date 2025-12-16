using Domain.Entidades.Base;
using Domain.Enums;

namespace Domain.Entidades.Sincronizacao;

/// <summary>
/// Representa um item na fila de sincronização.
/// Registra fichas finalizadas aguardando envio para o servidor.
/// </summary>
public class FilaSincronizacao : EntidadeBase
{
    /// <summary>
    /// ID da ficha a ser sincronizada.
    /// </summary>
    public Guid FichaId { get; set; }

    /// <summary>
    /// Tipo da ficha (nome da classe).
    /// </summary>
    public string TipoFicha { get; set; } = string.Empty;

    /// <summary>
    /// Tipo de operação (Criar, Atualizar, Excluir).
    /// </summary>
    public TipoOperacao TipoOperacao { get; set; }

    /// <summary>
    /// Status da sincronização.
    /// </summary>
    public StatusSincronizacao Status { get; set; }

    /// <summary>
    /// Número de tentativas de sincronização.
    /// </summary>
    public int TentativasRealizadas { get; set; }

    /// <summary>
    /// Data e hora da última tentativa de sincronização.
    /// </summary>
    public DateTime? UltimaTentativa { get; set; }

    /// <summary>
    /// Mensagem de erro da última tentativa (se houver).
    /// </summary>
    public string? MensagemErro { get; set; }

    /// <summary>
    /// Data e hora em que a ficha foi sincronizada com sucesso.
    /// </summary>
    public DateTime? DataSincronizacao { get; set; }

    /// <summary>
    /// Construtor que inicializa com status Pendente.
    /// </summary>
    public FilaSincronizacao()
    {
        Status = StatusSincronizacao.Pendente;
        TentativasRealizadas = 0;
    }

    /// <summary>
    /// Marca o item como em progresso.
    /// </summary>
    public void MarcarComoEmProgresso()
    {
        Status = StatusSincronizacao.EmProgresso;
        UltimaTentativa = DateTime.UtcNow;
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Marca o item como sincronizado com sucesso.
    /// </summary>
    public void MarcarComoSucesso()
    {
        Status = StatusSincronizacao.Sucesso;
        DataSincronizacao = DateTime.UtcNow;
        MensagemErro = null;
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Marca o item como erro e registra a mensagem.
    /// </summary>
    public void MarcarComoErro(string mensagemErro)
    {
        Status = StatusSincronizacao.Erro;
        TentativasRealizadas++;
        MensagemErro = mensagemErro;
        UltimaTentativa = DateTime.UtcNow;
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Verifica se deve tentar sincronizar novamente.
    /// </summary>
    public bool DeveRetentarSincronizacao(int maximoTentativas)
    {
        return Status == StatusSincronizacao.Erro && TentativasRealizadas < maximoTentativas;
    }
}
