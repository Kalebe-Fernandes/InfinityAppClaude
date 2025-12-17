using Domain.Entidades.Base;

namespace Domain.Entidades.Comum;

/// <summary>
/// Representa um material utilizado nos serviços.
/// </summary>
public class Material : EntidadeBase
{
    /// <summary>
    /// Código único do material no sistema Infinity.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descrição do material (ex: "CBUQ", "Cascalho").
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Unidade de medida do material (ex: "m³", "ton").
    /// </summary>
    public string Unidade { get; set; } = string.Empty;

    /// <summary>
    /// Navegação: Serviços que utilizam este material.
    /// </summary>
    public ICollection<Servico> Servicos { get; set; } = [];
}