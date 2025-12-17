using System.Text.Json.Serialization;

namespace Aplication.ApiInfinityResponse.Modelos;

/// <summary>
/// Resposta da API Infinity para listagem de equipamentos.
/// </summary>
public class EquipamentoResponse
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    [JsonPropertyName("prefixo")]
    public string? Prefixo { get; set; }

    [JsonPropertyName("placa")]
    public string? Placa { get; set; }

    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [JsonPropertyName("capacidade")]
    public decimal? Capacidade { get; set; }

    [JsonPropertyName("codigoObra")]
    public string? CodigoObra { get; set; }

    [JsonPropertyName("provisorio")]
    public bool Provisorio { get; set; }

    [JsonPropertyName("ativo")]
    public bool Ativo { get; set; }
}
