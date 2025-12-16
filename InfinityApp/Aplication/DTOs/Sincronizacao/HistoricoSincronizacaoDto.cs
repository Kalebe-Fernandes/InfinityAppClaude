namespace Aplication.DTOs.Sincronizacao;

/// <summary>
/// DTO para histórico de sincronização.
/// </summary>
public class HistoricoSincronizacaoDto
{
    /// <summary>
    /// ID do histórico.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Tipo de sincronização (Pull ou Push).
    /// </summary>
    public string Tipo { get; set; } = string.Empty;

    /// <summary>
    /// Nome do usuário que realizou a sincronização.
    /// </summary>
    public string UsuarioNome { get; set; } = string.Empty;

    /// <summary>
    /// Nome da obra (se aplicável).
    /// </summary>
    public string? ObraNome { get; set; }

    /// <summary>
    /// Quantidade de fichas processadas.
    /// </summary>
    public int QuantidadeFichas { get; set; }

    /// <summary>
    /// Quantidade de fichas com sucesso.
    /// </summary>
    public int QuantidadeSucesso { get; set; }

    /// <summary>
    /// Quantidade de fichas com erro.
    /// </summary>
    public int QuantidadeErro { get; set; }

    /// <summary>
    /// Status da sincronização.
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Data e hora de início.
    /// </summary>
    public DateTime DataInicio { get; set; }

    /// <summary>
    /// Data e hora de término.
    /// </summary>
    public DateTime? DataFim { get; set; }

    /// <summary>
    /// Duração em segundos.
    /// </summary>
    public int? DuracaoSegundos { get; set; }

    /// <summary>
    /// Detalhes ou log da sincronização.
    /// </summary>
    public string? Detalhes { get; set; }
}
