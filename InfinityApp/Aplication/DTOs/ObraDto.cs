namespace Aplication.DTOs;

/// <summary>
/// DTO para transferência de dados de Obra.
/// </summary>
public class ObraDto
{
    /// <summary>
    /// ID da obra.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Código único da obra.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Nome da obra.
    /// </summary>
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Descrição da obra.
    /// </summary>
    public string? Descricao { get; set; }

    /// <summary>
    /// Data de início da obra.
    /// </summary>
    public DateTime DataInicio { get; set; }

    /// <summary>
    /// Data de término da obra.
    /// </summary>
    public DateTime? DataFim { get; set; }

    /// <summary>
    /// Indica se a obra está ativa.
    /// </summary>
    public bool Ativa { get; set; }

    public string Numero { get; set; }
}
