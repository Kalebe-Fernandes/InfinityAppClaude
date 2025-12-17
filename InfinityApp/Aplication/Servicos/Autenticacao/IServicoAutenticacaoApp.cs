using Aplication.DTOs.Autenticacao;

namespace Aplication.Servicos.Autenticacao;

/// <summary>
/// Interface para serviço de autenticação na camada Application.
/// </summary>
public interface IServicoAutenticacaoApp
{
    /// <summary>
    /// Inicia o processo de login e retorna a URL de autenticação.
    /// </summary>
    Task<string> IniciarLoginAsync();

    /// <summary>
    /// Processa o callback de autenticação após o usuário fazer login.
    /// </summary>
    Task<TokenDto> ProcessarCallbackAsync(string callbackUrl);

    /// <summary>
    /// Verifica se o usuário está autenticado.
    /// </summary>
    Task<bool> EstaAutenticadoAsync();

    /// <summary>
    /// Obtém as informações do usuário autenticado.
    /// </summary>
    Task<UsuarioDto?> ObterUsuarioAsync();

    /// <summary>
    /// Realiza o logout do usuário.
    /// </summary>
    Task LogoutAsync();

    /// <summary>
    /// Obtém o token de acesso atual.
    /// </summary>
    Task<string?> ObterAccessTokenAsync();
}
