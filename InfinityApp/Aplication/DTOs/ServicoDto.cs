namespace Aplication.DTOs;

/// <summary>
/// DTO para transferência de dados de Serviço.
/// </summary>
public class ServicoDto
{
    /// <summary>
    /// ID do serviço.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Código único do serviço.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descrição do serviço.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Unidade de medida do serviço.
    /// </summary>
    public string Unidade { get; set; } = string.Empty;

    /// <summary>
    /// Indica se o serviço está ativo.
    /// </summary>
    public bool Ativo { get; set; }

    /// <summary>
    /// ID da obra à qual o serviço pertence.
    /// </summary>
    public Guid ObraId { get; set; }
}
