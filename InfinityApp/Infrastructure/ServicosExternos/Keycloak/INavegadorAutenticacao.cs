namespace Infrastructure.ServicosExternos.Keycloak;

/// <summary>
/// Interface para serviço de navegador de autenticação.
/// </summary>
public interface INavegadorAutenticacao
{
    /// <summary>
    /// Abre a URL de autenticação no navegador.
    /// </summary>
    /// <param name="url">URL de autenticação.</param>
    /// <param name="callbackUrl">URL de callback para retorno.</param>
    /// <returns>URL de callback com os parâmetros de resposta.</returns>
    Task<string> AbrirUrlAutenticacaoAsync(string url, string callbackUrl);
}
