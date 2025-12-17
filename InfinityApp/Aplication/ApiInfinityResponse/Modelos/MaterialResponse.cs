using System.Text.Json.Serialization;

namespace Aplication.ApiInfinityResponse.Modelos;

/// <summary>
/// Resposta da API Infinity para listagem de materiais.
/// </summary>
public class MaterialResponse
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = string.Empty;

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [JsonPropertyName("unidade")]
    public string Unidade { get; set; } = string.Empty;

    [JsonPropertyName("codigoServico")]
    public string? CodigoServico { get; set; }

    [JsonPropertyName("obrigatorio")]
    public bool Obrigatorio { get; set; }

    [JsonPropertyName("ativo")]
    public bool Ativo { get; set; }
}
