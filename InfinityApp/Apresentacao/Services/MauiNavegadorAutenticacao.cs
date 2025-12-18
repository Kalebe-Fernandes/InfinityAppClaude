using Infrastructure.ServicosExternos.Keycloak;

namespace Apresentacao.Services;

/// <summary>
/// Implementação MAUI do navegador de autenticação.
/// Usa WebAuthenticator do .NET MAUI que implementa:
/// - Android: Chrome Custom Tabs
/// - iOS: ASWebAuthenticationSession
/// - Windows: WebView2
/// </summary>
public class MauiNavegadorAutenticacao : INavegadorAutenticacao
{
    /// <summary>
    /// Abre a URL de autenticação usando WebAuthenticator do MAUI.
    /// No Android, usa Chrome Custom Tabs automaticamente quando disponível.
    /// </summary>
    public async Task<string> AbrirUrlAutenticacaoAsync(string url, string callbackUrl)
    {
        try
        {
            // WebAuthenticator do MAUI usa Chrome Custom Tabs no Android automaticamente
            var result = await WebAuthenticator.Default.AuthenticateAsync(
                new Uri(url),
                new Uri(callbackUrl)
            );

            // Reconstruir URL de callback com parâmetros
            var queryString = string.Join("&", result.Properties.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value)}"));
            return $"{callbackUrl}?{queryString}";
        }
        catch (TaskCanceledException)
        {
            // Usuário cancelou a autenticação
            throw new InvalidOperationException("Autenticação cancelada pelo usuário.");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Erro na autenticação: {ex.Message}", ex);
        }
    }
}
