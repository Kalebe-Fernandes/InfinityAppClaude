using Aplication.DTOs.Autenticacao;
using Aplication.Servicos.Interfaces;
using AutoMapper;

namespace Aplication.Servicos.Autenticacao;

/// <summary>
/// Implementação do serviço de autenticação na camada Application.
/// Encapsula o serviço de autenticação da Infrastructure.
/// </summary>
public class ServicoAutenticacaoApp(IAutenticacaoService autenticacaoService, IMapper mapper) : IServicoAutenticacaoApp
{
    private readonly IAutenticacaoService _autenticacaoService = autenticacaoService;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Inicia o processo de login e retorna a URL de autenticação.
    /// </summary>
    public async Task<string> IniciarLoginAsync()
    {
        return await _autenticacaoService.LoginAsync();
    }

    /// <summary>
    /// Processa o callback de autenticação após o usuário fazer login.
    /// </summary>
    public async Task<TokenDto> ProcessarCallbackAsync(string callbackUrl)
    {
        return await _autenticacaoService.ProcessarCallbackAsync(callbackUrl);
    }

    /// <summary>
    /// Verifica se o usuário está autenticado.
    /// </summary>
    public async Task<bool> EstaAutenticadoAsync()
    {
        return await _autenticacaoService.EstaAutenticadoAsync();
    }

    /// <summary>
    /// Obtém as informações do usuário autenticado.
    /// </summary>
    public async Task<UsuarioDto?> ObterUsuarioAsync()
    {
        var usuario = await _autenticacaoService.ObterInformacoesUsuarioAsync();
        
        if (usuario == null)
            return null;

        return new UsuarioDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email
        };
    }

    /// <summary>
    /// Realiza o logout do usuário.
    /// </summary>
    public async Task LogoutAsync()
    {
        await _autenticacaoService.LogoutAsync();
    }

    /// <summary>
    /// Obtém o token de acesso atual.
    /// </summary>
    public async Task<string?> ObterAccessTokenAsync()
    {
        return await _autenticacaoService.ObterAccessTokenAsync();
    }
}
