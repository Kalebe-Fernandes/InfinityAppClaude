using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositorios;
using Domain.Entidades.Fichas.Base;
using Infrastructure.Persistencia.Contexto;
using Domain.Enums;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Repositório base genérico para fichas.
/// Implementa funcionalidades comuns a todas as fichas.
/// </summary>
public class FichaRepositorioBase<TFicha>(InfinityAppDbContext contexto) : RepositorioBase<TFicha>(contexto), IFichaRepositorio<TFicha>
    where TFicha : FichaBase
{
    public virtual async Task<IEnumerable<TFicha>> ObterFichasPorObraAsync(Guid obraId)
    {
        return await _dbSet
            .Where(f => f.ObraId == obraId)
            .Include(f => f.Obra)
            .Include(f => f.Servico)
            .Include(f => f.Trecho)
            .Include(f => f.EquipamentoExecucao)
            .OrderByDescending(f => f.DataProducao)
            .ThenByDescending(f => f.Numero)
            .AsNoTracking()
            .ToListAsync();
    }

    public virtual async Task<IEnumerable<TFicha>> ObterFichasPorStatusAsync(StatusFicha status, Guid? obraId = null)
    {
        var query = _dbSet.Where(f => f.Status == status);

        if (obraId.HasValue)
        {
            query = query.Where(f => f.ObraId == obraId.Value);
        }

        return await query
            .Include(f => f.Obra)
            .Include(f => f.Servico)
            .Include(f => f.Trecho)
            .Include(f => f.EquipamentoExecucao)
            .OrderByDescending(f => f.DataProducao)
            .ThenByDescending(f => f.Numero)
            .AsNoTracking()
            .ToListAsync();
    }

    public virtual async Task<IEnumerable<TFicha>> ObterFichasPendentesSincronizacaoAsync(Guid? obraId = null)
    {
        var query = _dbSet.Where(f => f.Status == StatusFicha.Finalizada);

        if (obraId.HasValue)
        {
            query = query.Where(f => f.ObraId == obraId.Value);
        }

        return await query
            .OrderBy(f => f.DataProducao)
            .ThenBy(f => f.Numero)
            .AsNoTracking()
            .ToListAsync();
    }

    public virtual async Task<IEnumerable<TFicha>> ObterFichasPorPeriodoAsync(DateTime dataInicio, DateTime dataFim, Guid? obraId = null)
    {
        var query = _dbSet.Where(f => f.DataProducao >= dataInicio && f.DataProducao <= dataFim);

        if (obraId.HasValue)
        {
            query = query.Where(f => f.ObraId == obraId.Value);
        }

        return await query
            .Include(f => f.Obra)
            .Include(f => f.Servico)
            .Include(f => f.Trecho)
            .OrderBy(f => f.DataProducao)
            .ThenBy(f => f.Numero)
            .AsNoTracking()
            .ToListAsync();
    }

    public virtual async Task<int> ObterUltimoNumeroFichaAsync(Guid obraId)
    {
        var ultimaFicha = await _dbSet
            .Where(f => f.ObraId == obraId)
            .OrderByDescending(f => f.Numero)
            .FirstOrDefaultAsync();

        return ultimaFicha?.Numero ?? 0;
    }
}
