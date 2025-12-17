using Aplication.DTOs;
using AutoMapper;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Comum;

/// <summary>
/// Serviço para gerenciamento de serviços de obras.
/// </summary>
public class ServicoServico(IServicoRepositorio repositorio, IMapper mapper) : IServicoServico
{
    private readonly IServicoRepositorio _repositorio = repositorio;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ServicoDto>> ObterTodosAsync()
    {
        var servicos = await _repositorio.ObterTodosAsync();
        return _mapper.Map<IEnumerable<ServicoDto>>(servicos);
    }

    public async Task<IEnumerable<ServicoDto>> ObterPorObraAsync(Guid obraId)
    {
        var servicos = await _repositorio.ObterServicosPorObraAsync(obraId);
        return _mapper.Map<IEnumerable<ServicoDto>>(servicos);
    }

    public async Task<ServicoDto?> ObterPorIdAsync(Guid id)
    {
        var servico = await _repositorio.ObterPorIdAsync(id);
        return servico != null ? _mapper.Map<ServicoDto>(servico) : null;
    }
}
