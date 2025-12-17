using System.Text.Json.Serialization;

namespace Aplication.ApiInfinityResponse.Modelos;

/// <summary>
/// Resposta da API Infinity para listagem de trechos.
/// </summary>
public class TrechoResponse
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [JsonPropertyName("codigoObra")]
    public string CodigoObra { get; set; } = string.Empty;

    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [JsonPropertyName("pistaDupla")]
    public bool PistaDupla { get; set; }

    [JsonPropertyName("estacaInicial")]
    public decimal EstacaInicial { get; set; }

    [JsonPropertyName("estacaFinal")]
    public decimal EstacaFinal { get; set; }
}
