using Aplication.DTOs.Fichas;
using Aplication.Servicos.Interfaces;
using AutoMapper;
using Domain.Entidades.Fichas.Base;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Fichas;

/// <summary>
/// Serviço base genérico para fichas.
/// Contém implementação comum para todas as fichas.
/// </summary>
public abstract class ServicoFichaBase<TFicha, TFichaDto>(IRepositorio<TFicha> repositorio, IUnitOfWork unitOfWork, IMapper mapper) : IServicoFicha<TFichaDto>
    where TFicha : FichaBase
    where TFichaDto : FichaBaseDto
{
    protected readonly IRepositorio<TFicha> _repositorio = repositorio;
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;

    public virtual async Task<TFichaDto> CriarAsync(TFichaDto fichaDto)
    {
        var ficha = _mapper.Map<TFicha>(fichaDto);

        if (ficha.Numero == 0)
        {
            ficha.Numero = await ObterProximoNumeroFichaAsync(ficha.ObraId);
        }

        await _repositorio.AdicionarAsync(ficha);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<TFichaDto>(ficha);
    }

    public virtual async Task<TFichaDto> AtualizarAsync(TFichaDto fichaDto)
    {
        var ficha = await _repositorio.ObterPorIdAsync(fichaDto.Id) ?? throw new InvalidOperationException("Ficha não encontrada.");
        if (!ficha.PodeSerEditada())
            throw new InvalidOperationException("Apenas fichas pendentes podem ser editadas.");

        _mapper.Map(fichaDto, ficha);

        _repositorio.Atualizar(ficha);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<TFichaDto>(ficha);
    }

    public virtual async Task<TFichaDto?> ObterPorIdAsync(Guid id)
    {
        var ficha = await _repositorio.ObterPorIdAsync(id);
        return ficha != null ? _mapper.Map<TFichaDto>(ficha) : null;
    }

    public virtual async Task<IEnumerable<TFichaDto>> ObterPorObraAsync(Guid obraId)
    {
        var fichas = await _repositorio.BuscarAsync(f => f.ObraId == obraId);
        return _mapper.Map<IEnumerable<TFichaDto>>(fichas);
    }

    public virtual async Task<IEnumerable<TFichaDto>> ObterPorStatusAsync(string status, Guid? obraId = null)
    {
        var fichas = obraId.HasValue
            ? await _repositorio.BuscarAsync(f => f.Status.ToString() == status && f.ObraId == obraId.Value)
            : await _repositorio.BuscarAsync(f => f.Status.ToString() == status);

        return _mapper.Map<IEnumerable<TFichaDto>>(fichas);
    }

    public virtual async Task<bool> FinalizarAsync(Guid fichaId)
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

    public virtual async Task<bool> DesfinalizarAsync(Guid fichaId)
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

    public virtual async Task<bool> CancelarAsync(Guid fichaId)
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

    public virtual async Task<bool> ExcluirAsync(Guid fichaId)
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

    public virtual async Task<int> ObterProximoNumeroFichaAsync(Guid obraId)
    {
        var fichas = await _repositorio.BuscarAsync(f => f.ObraId == obraId);
        var ultimoNumero = fichas.Any() ? fichas.Max(f => f.Numero) : 0;
        return ultimoNumero + 1;
    }
}
