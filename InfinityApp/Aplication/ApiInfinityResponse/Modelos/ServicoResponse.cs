using System.Text.Json.Serialization;

namespace Aplication.ApiInfinityResponse.Modelos;

/// <summary>
/// Resposta da API Infinity para listagem de serviços.
/// </summary>
public class ServicoResponse
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [JsonPropertyName("unidade")]
    public string Unidade { get; set; } = string.Empty;

    [JsonPropertyName("codigoObra")]
    public string CodigoObra { get; set; } = string.Empty;

    [JsonPropertyName("categoria")]
    public string? Categoria { get; set; }

    [JsonPropertyName("frenteServicoId")]
    public string? FrenteServicoId { get; set; }

    [JsonPropertyName("ativo")]
    public bool Ativo { get; set; }
}
