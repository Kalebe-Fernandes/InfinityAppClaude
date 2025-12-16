using Aplication.DTOs.Fichas;
using Aplication.Servicos.Interfaces;
using AutoMapper;
using Domain.Entidades.Fichas;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Fichas;

/// <summary>
/// Serviço de aplicação para Ficha de Viagens de CB.
/// </summary>
public class ServicoFichaViagemCB(
    IRepositorio<FichaViagemCB> repositorio,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IServicoFicha<FichaViagemCBDto>
{
    private readonly IRepositorio<FichaViagemCB> _repositorio = repositorio;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<FichaViagemCBDto> CriarAsync(FichaViagemCBDto fichaDto)
    {
        var ficha = _mapper.Map<FichaViagemCB>(fichaDto);

        if (ficha.Numero == 0)
        {
            ficha.Numero = await ObterProximoNumeroFichaAsync(ficha.ObraId);
        }

        await _repositorio.AdicionarAsync(ficha);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<FichaViagemCBDto>(ficha);
    }

    public async Task<FichaViagemCBDto> AtualizarAsync(FichaViagemCBDto fichaDto)
    {
        var ficha = await _repositorio.ObterPorIdAsync(fichaDto.Id) ?? throw new InvalidOperationException("Ficha não encontrada.");

        if (!ficha.PodeSerEditada())
            throw new InvalidOperationException("Apenas fichas pendentes podem ser editadas.");

        _mapper.Map(fichaDto, ficha);

        _repositorio.Atualizar(ficha);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<FichaViagemCBDto>(ficha);
    }

    public async Task<FichaViagemCBDto?> ObterPorIdAsync(Guid id)
    {
        var ficha = await _repositorio.ObterPorIdAsync(id);
        return ficha != null ? _mapper.Map<FichaViagemCBDto>(ficha) : null;
    }

    public async Task<IEnumerable<FichaViagemCBDto>> ObterPorObraAsync(Guid obraId)
    {
        var fichas = await _repositorio.BuscarAsync(f => f.ObraId == obraId);
        return _mapper.Map<IEnumerable<FichaViagemCBDto>>(fichas);
    }

    public async Task<IEnumerable<FichaViagemCBDto>> ObterPorStatusAsync(string status, Guid? obraId = null)
    {
        var fichas = obraId.HasValue
            ? await _repositorio.BuscarAsync(f => f.Status.ToString() == status && f.ObraId == obraId.Value)
            : await _repositorio.BuscarAsync(f => f.Status.ToString() == status);

        return _mapper.Map<IEnumerable<FichaViagemCBDto>>(fichas);
    }

    public async Task<bool> FinalizarAsync(Guid fichaId)
    {
        var ficha = await _repositorio.ObterPorIdAsync(fichaId);

        if (ficha == null)
            return false;

        try
        {
            ficha.Finalizar();
            _repositorio.Atualizar(ficha);
            await _unitOfWork.CommitAsync();
            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }

    public async Task<bool> DesfinalizarAsync(Guid fichaId)
    {
        var ficha = await _repositorio.ObterPorIdAsync(fichaId);

        if (ficha == null)
            return false;

        try
        {
            ficha.Desfinalizar();
            _repositorio.Atualizar(ficha);
            await _unitOfWork.CommitAsync();
            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }

    public async Task<bool> CancelarAsync(Guid fichaId)
    {
        var ficha = await _repositorio.ObterPorIdAsync(fichaId);

        if (ficha == null)
            return false;

        try
        {
            ficha.Cancelar();
            _repositorio.Atualizar(ficha);
            await _unitOfWork.CommitAsync();
            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }

    public async Task<bool> ExcluirAsync(Guid fichaId)
    {
        var ficha = await _repositorio.ObterPorIdAsync(fichaId);

        if (ficha == null)
            return false;

        if (!ficha.PodeSerExcluida())
            return false;

        _repositorio.Remover(ficha);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<int> ObterProximoNumeroFichaAsync(Guid obraId)
    {
        var fichas = await _repositorio.BuscarAsync(f => f.ObraId == obraId);
        var ultimoNumero = fichas.Any() ? fichas.Max(f => f.Numero) : 0;
        return ultimoNumero + 1;
    }

    /// <summary>
    /// Adiciona um equipamento de transporte à ficha.
    /// </summary>
    public async Task<bool> AdicionarEquipamentoAsync(Guid fichaId, Guid equipamentoId)
    {
        var ficha = await _repositorio.ObterPorIdAsync(fichaId);

        if (ficha == null)
            return false;

        try
        {
            ficha.AdicionarEquipamento(equipamentoId);
            _repositorio.Atualizar(ficha);
            await _unitOfWork.CommitAsync();
            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }

    /// <summary>
    /// Troca um equipamento de transporte da ficha.
    /// </summary>
    public async Task<bool> TrocarEquipamentoAsync(Guid fichaId, Guid equipamentoAntigoId, Guid equipamentoNovoId)
    {
        var ficha = await _repositorio.ObterPorIdAsync(fichaId);

        if (ficha == null)
            return false;

        try
        {
            ficha.TrocarEquipamento(equipamentoAntigoId, equipamentoNovoId);
            _repositorio.Atualizar(ficha);
            await _unitOfWork.CommitAsync();
            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }
}
