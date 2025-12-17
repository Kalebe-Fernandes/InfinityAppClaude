using System.Text.Json.Serialization;

namespace Aplication.ApiInfinityResponse.Modelos;

/// <summary>
/// Resposta da API Infinity para listagem de obras.
/// </summary>
public class ObraResponse
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    [JsonPropertyName("numero")]
    public string Numero { get; set; } = string.Empty;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("descricao")]
    public string? Descricao { get; set; }

    [JsonPropertyName("ativa")]
    public bool Ativa { get; set; }

    [JsonPropertyName("dataInicio")]
    public DateTime DataInicio { get; set; }

    [JsonPropertyName("dataFim")]
    public DateTime? DataFim { get; set; }
}
