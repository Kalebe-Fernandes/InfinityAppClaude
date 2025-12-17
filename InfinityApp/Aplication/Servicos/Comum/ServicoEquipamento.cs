using Aplication.DTOs;
using AutoMapper;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Comum;

/// <summary>
/// Serviço para gerenciamento de equipamentos.
/// </summary>
public class ServicoEquipamento(IEquipamentoRepositorio repositorio, IMapper mapper) : IServicoEquipamento
{
    private readonly IEquipamentoRepositorio _repositorio = repositorio;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<EquipamentoDto>> ObterTodosAsync()
    {
        var equipamentos = await _repositorio.ObterTodosAsync();
        return _mapper.Map<IEnumerable<EquipamentoDto>>(equipamentos);
    }

    public async Task<IEnumerable<EquipamentoDto>> ObterPorTipoAsync(string tipo)
    {
        var todos = await _repositorio.ObterTodosAsync();
        var filtrados = todos.Where(e => e.Tipo.ToString() == tipo);
        return _mapper.Map<IEnumerable<EquipamentoDto>>(filtrados);
    }

    public async Task<EquipamentoDto?> ObterPorIdAsync(Guid id)
    {
        var equipamento = await _repositorio.ObterPorIdAsync(id);
        return equipamento != null ? _mapper.Map<EquipamentoDto>(equipamento) : null;
    }
}
