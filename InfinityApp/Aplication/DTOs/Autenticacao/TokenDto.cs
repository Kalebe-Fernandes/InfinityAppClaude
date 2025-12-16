namespace Aplication.DTOs.Autenticacao;

/// <summary>
/// DTO para tokens de autenticação OAuth 2.0.
/// </summary>
public class TokenDto
{
    /// <summary>
    /// Access Token (não será armazenado, usado apenas em memória).
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// Refresh Token (será armazenado no Android Keystore).
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;

    /// <summary>
    /// ID Token com informações do usuário.
    /// </summary>
    public string IdToken { get; set; } = string.Empty;

    /// <summary>
    /// Tempo de expiração do Access Token em segundos.
    /// </summary>
    public int ExpiresIn { get; set; }

    /// <summary>
    /// Tempo de expiração do Refresh Token em segundos.
    /// </summary>
    public int RefreshExpiresIn { get; set; }

    /// <summary>
    /// Tipo do token (geralmente "Bearer").
    /// </summary>
    public string TokenType { get; set; } = "Bearer";

    /// <summary>
    /// Data e hora de emissão do token.
    /// </summary>
    public DateTime DataEmissao { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Verifica se o token está próximo de expirar (24 horas).
    /// </summary>
    public bool ProximoDeExpirar()
    {
        var dataExpiracao = DataEmissao.AddSeconds(RefreshExpiresIn);
        var horasRestantes = (dataExpiracao - DateTime.UtcNow).TotalHours;
        return horasRestantes <= 24;
    }

    /// <summary>
    /// Verifica se o token já expirou.
    /// </summary>
    public bool Expirado()
    {
        var dataExpiracao = DataEmissao.AddSeconds(RefreshExpiresIn);
        return DateTime.UtcNow >= dataExpiracao;
    }
}
