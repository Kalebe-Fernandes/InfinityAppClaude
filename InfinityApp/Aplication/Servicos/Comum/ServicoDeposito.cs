using Aplication.DTOs;
using AutoMapper;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Comum;

/// <summary>
/// Serviço para gerenciamento de depósitos.
/// </summary>
public class ServicoDeposito(IDepositoRepositorio repositorio, IMapper mapper) : IServicoDeposito
{
    private readonly IDepositoRepositorio _repositorio = repositorio;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<DepositoDto>> ObterTodosAsync()
    {
        var depositos = await _repositorio.ObterTodosAsync();
        return _mapper.Map<IEnumerable<DepositoDto>>(depositos);
    }

    public async Task<DepositoDto?> ObterPorIdAsync(Guid id)
    {
        var deposito = await _repositorio.ObterPorIdAsync(id);
        return deposito != null ? _mapper.Map<DepositoDto>(deposito) : null;
    }
}
