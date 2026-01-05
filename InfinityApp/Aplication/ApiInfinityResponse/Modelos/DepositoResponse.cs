using System.Text.Json.Serialization;

namespace Aplication.ApiInfinityResponse.Modelos;

/// <summary>
/// Resposta da API Infinity para listagem de depósitos.
/// </summary>
public class DepositoResponse
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("codigoObra")]
    public string? CodigoObra { get; set; }

    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }

    [JsonPropertyName("provisorio")]
    public bool Provisorio { get; set; }

    [JsonPropertyName("ativo")]
    public bool Ativo { get; set; }
}
