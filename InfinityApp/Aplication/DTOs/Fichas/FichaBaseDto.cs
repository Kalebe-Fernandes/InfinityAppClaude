namespace Aplication.DTOs.Fichas;

/// <summary>
/// DTO base para todas as fichas de serviço.
/// Contém propriedades comuns a todos os tipos de fichas.
/// </summary>
public abstract class FichaBaseDto
{
    /// <summary>
    /// ID da ficha.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Número sequencial da ficha.
    /// </summary>
    public int Numero { get; set; }

    /// <summary>
    /// Data de produção do serviço.
    /// </summary>
    public DateTime DataProducao { get; set; }

    /// <summary>
    /// ID da obra.
    /// </summary>
    public Guid ObraId { get; set; }

    /// <summary>
    /// Nome da obra (para exibição).
    /// </summary>
    public string? ObraNome { get; set; }

    /// <summary>
    /// ID do serviço.
    /// </summary>
    public Guid ServicoId { get; set; }

    /// <summary>
    /// Descrição do serviço (para exibição).
    /// </summary>
    public string? ServicoDescricao { get; set; }

    /// <summary>
    /// ID do trecho.
    /// </summary>
    public Guid TrechoId { get; set; }

    /// <summary>
    /// Descrição do trecho (para exibição).
    /// </summary>
    public string? TrechoDescricao { get; set; }

    /// <summary>
    /// Pista (nullable, obrigatório apenas se trecho for pista dupla).
    /// </summary>
    public string? Pista { get; set; }

    /// <summary>
    /// ID do equipamento de execução.
    /// </summary>
    public Guid EquipamentoExecucaoId { get; set; }

    /// <summary>
    /// Descrição do equipamento (para exibição).
    /// </summary>
    public string? EquipamentoDescricao { get; set; }

    /// <summary>
    /// Observações gerais.
    /// </summary>
    public string? Observacoes { get; set; }

    /// <summary>
    /// Status da ficha.
    /// </summary>
    public string Status { get; set; } = "Pendente";

    /// <summary>
    /// Data de criação.
    /// </summary>
    public DateTime DataCriacao { get; set; }

    /// <summary>
    /// Data de atualização.
    /// </summary>
    public DateTime DataAtualizacao { get; set; }
}
