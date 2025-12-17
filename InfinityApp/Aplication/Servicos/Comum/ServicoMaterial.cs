using Aplication.DTOs;
using AutoMapper;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Comum;

/// <summary>
/// Serviço para gerenciamento de materiais.
/// </summary>
public class ServicoMaterial(IMaterialRepositorio repositorio, IMapper mapper) : IServicoMaterial
{
    private readonly IMaterialRepositorio _repositorio = repositorio;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<MaterialDto>> ObterTodosAsync()
    {
        var materiais = await _repositorio.ObterTodosAsync();
        return _mapper.Map<IEnumerable<MaterialDto>>(materiais);
    }

    public async Task<MaterialDto?> ObterPorIdAsync(Guid id)
    {
        var material = await _repositorio.ObterPorIdAsync(id);
        return material != null ? _mapper.Map<MaterialDto>(material) : null;
    }
}
