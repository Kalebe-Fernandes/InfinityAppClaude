using System.Text.Json.Serialization;

namespace Infrastructure.ServicosExternos.Keycloak;

/// <summary>
/// Resposta do endpoint de user info do Keycloak.
/// </summary>
public class UserInfoResponse
{
    [JsonPropertyName("sub")]
    public string Sub { get; set; } = string.Empty;

    [JsonPropertyName("email_verified")]
    public bool EmailVerified { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("preferred_username")]
    public string PreferredUsername { get; set; } = string.Empty;

    [JsonPropertyName("given_name")]
    public string? GivenName { get; set; }

    [JsonPropertyName("family_name")]
    public string? FamilyName { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;
}
