using Aplication.DTOs.Fichas;
using Aplication.Servicos.Interfaces;
using AutoMapper;
using Domain.Entidades.Fichas;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Fichas;

/// <summary>
/// Serviço de aplicação para Ficha de Limpeza de Pista.
/// </summary>
public class ServicoFichaLimpezaPista(
    IRepositorio<FichaLimpezaPista> repositorio,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IServicoFicha<FichaLimpezaPistaDto>
{
    private readonly IRepositorio<FichaLimpezaPista> _repositorio = repositorio;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<FichaLimpezaPistaDto> CriarAsync(FichaLimpezaPistaDto fichaDto)
    {
        var ficha = _mapper.Map<FichaLimpezaPista>(fichaDto);

        // Define o número da ficha se não foi informado
        if (ficha.Numero == 0)
        {
            ficha.Numero = await ObterProximoNumeroFichaAsync(ficha.ObraId);
        }

        await _repositorio.AdicionarAsync(ficha);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<FichaLimpezaPistaDto>(ficha);
    }

    public async Task<FichaLimpezaPistaDto> AtualizarAsync(FichaLimpezaPistaDto fichaDto)
    {
        var ficha = await _repositorio.ObterPorIdAsync(fichaDto.Id) ?? throw new InvalidOperationException("Ficha não encontrada.");

        if (!ficha.PodeSerEditada())
            throw new InvalidOperationException("Apenas fichas pendentes podem ser editadas.");

        // Atualiza propriedades
        _mapper.Map(fichaDto, ficha);
        
        _repositorio.Atualizar(ficha);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<FichaLimpezaPistaDto>(ficha);
    }

    public async Task<FichaLimpezaPistaDto?> ObterPorIdAsync(Guid id)
    {
        var ficha = await _repositorio.ObterPorIdAsync(id);
        return ficha != null ? _mapper.Map<FichaLimpezaPistaDto>(ficha) : null;
    }

    public async Task<IEnumerable<FichaLimpezaPistaDto>> ObterPorObraAsync(Guid obraId)
    {
        var fichas = await _repositorio.BuscarAsync(f => f.ObraId == obraId);
        return _mapper.Map<IEnumerable<FichaLimpezaPistaDto>>(fichas);
    }

    public async Task<IEnumerable<FichaLimpezaPistaDto>> ObterPorStatusAsync(string status, Guid? obraId = null)
    {
        var fichas = obraId.HasValue
            ? await _repositorio.BuscarAsync(f => f.Status.ToString() == status && f.ObraId == obraId.Value)
            : await _repositorio.BuscarAsync(f => f.Status.ToString() == status);

        return _mapper.Map<IEnumerable<FichaLimpezaPistaDto>>(fichas);
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
}
