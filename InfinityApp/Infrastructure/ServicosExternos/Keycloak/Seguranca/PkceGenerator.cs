using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.ServicosExternos.Keycloak.Seguranca;

/// <summary>
/// Gerador de PKCE (Proof Key for Code Exchange) para OAuth 2.0.
/// Implementa RFC 7636 para proteção contra ataques de interceptação de código de autorização.
/// </summary>
public class PkceGenerator
{
    /// <summary>
    /// Gera um code verifier aleatório.
    /// </summary>
    /// <returns>Code verifier em base64url.</returns>
    public static string GerarCodeVerifier()
    {
        var bytes = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(bytes);
        }

        return Base64UrlEncode(bytes);
    }

    /// <summary>
    /// Gera um code challenge a partir do code verifier usando SHA256.
    /// </summary>
    /// <param name="codeVerifier">Code verifier.</param>
    /// <returns>Code challenge em base64url.</returns>
    public static string GerarCodeChallenge(string codeVerifier)
    {
        var challengeBytes = SHA256.HashData(Encoding.UTF8.GetBytes(codeVerifier));
        return Base64UrlEncode(challengeBytes);
    }

    /// <summary>
    /// Gera um state aleatório para proteção contra CSRF.
    /// </summary>
    /// <returns>State em base64url.</returns>
    public static string GerarState()
    {
        var bytes = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(bytes);
        }

        return Base64UrlEncode(bytes);
    }

    /// <summary>
    /// Codifica bytes em base64url (sem padding).
    /// </summary>
    private static string Base64UrlEncode(byte[] bytes)
    {
        return Convert.ToBase64String(bytes)
            .Replace("+", "-")
            .Replace("/", "_")
            .Replace("=", "");
    }

    /// <summary>
    /// Valida um code verifier.
    /// </summary>
    /// <param name="codeVerifier">Code verifier a validar.</param>
    /// <returns>True se válido, false caso contrário.</returns>
    public static bool ValidarCodeVerifier(string codeVerifier)
    {
        if (string.IsNullOrWhiteSpace(codeVerifier))
            return false;

        // Code verifier deve ter entre 43 e 128 caracteres
        if (codeVerifier.Length < 43 || codeVerifier.Length > 128)
            return false;

        // Deve conter apenas caracteres base64url
        return codeVerifier.All(c => 
            char.IsLetterOrDigit(c) || c == '-' || c == '_');
    }
}
