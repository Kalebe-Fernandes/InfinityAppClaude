using Aplication.DTOs;
using AutoMapper;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Comum;

/// <summary>
/// Serviço para gerenciamento de trechos.
/// </summary>
public class ServicoTrecho(ITrechoRepositorio repositorio, IMapper mapper) : IServicoTrecho
{
    private readonly ITrechoRepositorio _repositorio = repositorio;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<TrechoDto>> ObterTodosAsync()
    {
        var trechos = await _repositorio.ObterTodosAsync();
        return _mapper.Map<IEnumerable<TrechoDto>>(trechos);
    }

    public async Task<IEnumerable<TrechoDto>> ObterPorObraAsync(Guid obraId)
    {
        var trechos = await _repositorio.ObterTrechosPorObraAsync(obraId);
        return _mapper.Map<IEnumerable<TrechoDto>>(trechos);
    }

    public async Task<TrechoDto?> ObterPorIdAsync(Guid id)
    {
        var trecho = await _repositorio.ObterPorIdAsync(id);
        return trecho != null ? _mapper.Map<TrechoDto>(trecho) : null;
    }
}
