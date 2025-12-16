using Domain.Entidades.Fichas;
using Domain.Enums;
using Domain.Interfaces.Repositorios;
using Infrastructure.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Repositório específico para Ficha de Viagens de CB.
/// </summary>
public class FichaViagemCBRepositorio(InfinityAppDbContext contexto) : RepositorioBase<FichaViagemCB>(contexto), IFichaRepositorio<FichaViagemCB>
{
    public async Task<IEnumerable<FichaViagemCB>> ObterFichasPorObraAsync(Guid obraId)
    {
        return await _dbSet
            .Where(f => f.ObraId == obraId)
            .Include(f => f.Obra)
            .Include(f => f.Servico)
            .Include(f => f.Trecho)
            .Include(f => f.EquipamentoExecucao)
            .Include(f => f.DepositoOrigem)
            .Include(f => f.DepositoDestino)
            .Include(f => f.Equipamentos)
                .ThenInclude(e => e.Equipamento)
            .Include(f => f.Apontamentos)
                .ThenInclude(a => a.Equipamento)
            .Include(f => f.Apontamentos)
                .ThenInclude(a => a.Material)
            .OrderByDescending(f => f.DataProducao)
            .ThenByDescending(f => f.Numero)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<FichaViagemCB>> ObterFichasPorStatusAsync(StatusFicha status, Guid? obraId = null)
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
            .Include(f => f.DepositoOrigem)
            .Include(f => f.DepositoDestino)
            .Include(f => f.Equipamentos)
            .OrderByDescending(f => f.DataProducao)
            .ThenByDescending(f => f.Numero)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<FichaViagemCB>> ObterFichasPendentesSincronizacaoAsync(Guid? obraId = null)
    {
        var query = _dbSet.Where(f => f.Status == StatusFicha.Finalizada);

        if (obraId.HasValue)
        {
            query = query.Where(f => f.ObraId == obraId.Value);
        }

        return await query
            .Include(f => f.Equipamentos)
            .Include(f => f.Apontamentos)
            .OrderBy(f => f.DataProducao)
            .ThenBy(f => f.Numero)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<FichaViagemCB>> ObterFichasPorPeriodoAsync(DateTime dataInicio, DateTime dataFim, Guid? obraId = null)
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
            .Include(f => f.DepositoOrigem)
            .Include(f => f.DepositoDestino)
            .Include(f => f.Equipamentos)
            .Include(f => f.Apontamentos)
            .OrderBy(f => f.DataProducao)
            .ThenBy(f => f.Numero)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> ObterUltimoNumeroFichaAsync(Guid obraId)
    {
        var ultimaFicha = await _dbSet
            .Where(f => f.ObraId == obraId)
            .OrderByDescending(f => f.Numero)
            .FirstOrDefaultAsync();

        return ultimaFicha?.Numero ?? 0;
    }
}
