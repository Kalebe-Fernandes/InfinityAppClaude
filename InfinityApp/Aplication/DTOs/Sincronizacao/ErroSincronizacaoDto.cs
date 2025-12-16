namespace Aplication.DTOs.Sincronizacao;

/// <summary>
/// DTO para erro detalhado de sincronização.
/// </summary>
public class ErroSincronizacaoDto
{
    /// <summary>
    /// ID da ficha que gerou o erro.
    /// </summary>
    public Guid FichaId { get; set; }

    /// <summary>
    /// Número da ficha.
    /// </summary>
    public int NumeroFicha { get; set; }

    /// <summary>
    /// Tipo da ficha.
    /// </summary>
    public string TipoFicha { get; set; } = string.Empty;

    /// <summary>
    /// Mensagem de erro.
    /// </summary>
    public string MensagemErro { get; set; } = string.Empty;

    /// <summary>
    /// Data e hora do erro.
    /// </summary>
    public DateTime DataErro { get; set; }
}
