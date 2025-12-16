namespace Aplication.DTOs.Sincronizacao;

/// <summary>
/// DTO para resultado de sincronização.
/// </summary>
public class ResultadoSincronizacaoDto
{
    /// <summary>
    /// Indica se a sincronização foi bem-sucedida.
    /// </summary>
    public bool Sucesso { get; set; }

    /// <summary>
    /// Tipo de sincronização (Pull ou Push).
    /// </summary>
    public string Tipo { get; set; } = string.Empty;

    /// <summary>
    /// Quantidade total de itens processados.
    /// </summary>
    public int QuantidadeTotal { get; set; }

    /// <summary>
    /// Quantidade de itens sincronizados com sucesso.
    /// </summary>
    public int QuantidadeSucesso { get; set; }

    /// <summary>
    /// Quantidade de itens com erro.
    /// </summary>
    public int QuantidadeErro { get; set; }

    /// <summary>
    /// Mensagem geral do resultado.
    /// </summary>
    public string? Mensagem { get; set; }

    /// <summary>
    /// Lista de erros detalhados (se houver).
    /// </summary>
    public List<ErroSincronizacaoDto> Erros { get; set; } = [];

    /// <summary>
    /// Data e hora de início da sincronização.
    /// </summary>
    public DateTime DataInicio { get; set; }

    /// <summary>
    /// Data e hora de término da sincronização.
    /// </summary>
    public DateTime DataFim { get; set; }

    /// <summary>
    /// Duração total em segundos.
    /// </summary>
    public int DuracaoSegundos { get; set; }
}
