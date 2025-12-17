using Aplication.DTOs;
using AutoMapper;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Comum;

/// <summary>
/// Serviço para gerenciamento de obras.
/// </summary>
public class ServicoObra(IObraRepositorio repositorio, IMapper mapper) : IServicoObra
{
    private readonly IObraRepositorio _repositorio = repositorio;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Obtém todas as obras.
    /// </summary>
    public async Task<IEnumerable<ObraDto>> ObterTodasAsync()
    {
        var obras = await _repositorio.ObterTodosAsync();
        return _mapper.Map<IEnumerable<ObraDto>>(obras);
    }

    /// <summary>
    /// Obtém todas as obras ativas.
    /// </summary>
    public async Task<IEnumerable<ObraDto>> ObterTodasAtivasAsync()
    {
        var obras = await _repositorio.ObterObrasAtivasAsync();
        return _mapper.Map<IEnumerable<ObraDto>>(obras);
    }

    /// <summary>
    /// Obtém uma obra por ID.
    /// </summary>
    public async Task<ObraDto?> ObterPorIdAsync(Guid id)
    {
        var obra = await _repositorio.ObterPorIdAsync(id);
        return obra != null ? _mapper.Map<ObraDto>(obra) : null;
    }

    /// <summary>
    /// Obtém uma obra por código.
    /// </summary>
    public async Task<ObraDto?> ObterPorCodigoAsync(string codigo)
    {
        var obra = await _repositorio.ObterPorCodigoAsync(codigo);
        return obra != null ? _mapper.Map<ObraDto>(obra) : null;
    }

    /// <summary>
    /// Busca obras por termo (nome, código ou número).
    /// </summary>
    public async Task<IEnumerable<ObraDto>> BuscarAsync(string termo)
    {
        var todasObras = await _repositorio.ObterObrasAtivasAsync();
        
        var termoLower = termo.ToLower();
        var obrasFiltradas = todasObras.Where(o =>
            o.Nome.Contains(termoLower, StringComparison.CurrentCultureIgnoreCase) ||
            o.Codigo.Contains(termoLower, StringComparison.CurrentCultureIgnoreCase) ||
            o.Numero.Contains(termoLower, StringComparison.CurrentCultureIgnoreCase)
        );

        return _mapper.Map<IEnumerable<ObraDto>>(obrasFiltradas);
    }
}
