using System.Text.Json.Serialization;

namespace Infrastructure.ServicosExternos.Keycloak;

/// <summary>
/// Resposta de erro do Keycloak.
/// </summary>
public class ErrorResponse
{
    [JsonPropertyName("error")]
    public string Error { get; set; } = string.Empty;

    [JsonPropertyName("error_description")]
    public string ErrorDescription { get; set; } = string.Empty;
}
