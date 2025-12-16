namespace Aplication.DTOs;

/// <summary>
/// DTO para transferência de dados de Material.
/// </summary>
public class MaterialDto
{
    /// <summary>
    /// ID do material.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Código único do material.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descrição do material.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Unidade de medida do material.
    /// </summary>
    public string Unidade { get; set; } = string.Empty;
}
