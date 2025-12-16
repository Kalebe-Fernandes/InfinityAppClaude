using Microsoft.EntityFrameworkCore;
using Domain.Entidades.Comum;
using Domain.Interfaces.Repositorios;
using Infrastructure.Persistencia.Contexto;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Implementação do repositório de Trechos.
/// </summary>
public class TrechoRepositorio(InfinityAppDbContext contexto) : RepositorioBase<Trecho>(contexto), ITrechoRepositorio
{
    public async Task<IEnumerable<Trecho>> ObterTrechosPorObraAsync(Guid obraId)
    {
        return await _dbSet
            .Where(t => t.ObraId == obraId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Trecho?> ObterPorCodigoAsync(string codigo)
    {
        return await _dbSet.FirstOrDefaultAsync(t => t.Codigo == codigo);
    }

    public async Task<IEnumerable<Trecho>> ObterTrechosPistaDuplaAsync(Guid obraId)
    {
        return await _dbSet
            .Where(t => t.ObraId == obraId && t.PistaDupla)
            .AsNoTracking()
            .ToListAsync();
    }
}
