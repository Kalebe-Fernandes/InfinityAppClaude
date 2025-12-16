using Microsoft.EntityFrameworkCore;
using Domain.Entidades.Comum;
using Domain.Interfaces.Repositorios;
using Infrastructure.Persistencia.Contexto;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Implementação do repositório de Depósitos.
/// </summary>
public class DepositoRepositorio(InfinityAppDbContext contexto) : RepositorioBase<Deposito>(contexto), IDepositoRepositorio
{
    public async Task<IEnumerable<Deposito>> ObterDepositosPorObraAsync(Guid obraId)
    {
        return await _dbSet
            .Where(d => d.ObraId == obraId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Deposito>> ObterDepositosProvisoriosAsync()
    {
        return await _dbSet
            .Where(d => d.Provisorio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Deposito?> ObterPorCodigoAsync(string codigo)
    {
        return await _dbSet.FirstOrDefaultAsync(d => d.Codigo == codigo);
    }
}
