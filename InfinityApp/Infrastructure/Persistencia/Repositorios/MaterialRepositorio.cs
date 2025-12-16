using Microsoft.EntityFrameworkCore;
using Domain.Entidades.Comum;
using Domain.Interfaces.Repositorios;
using Infrastructure.Persistencia.Contexto;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Implementação do repositório de Materiais.
/// </summary>
public class MaterialRepositorio(InfinityAppDbContext contexto) : RepositorioBase<Material>(contexto), IMaterialRepositorio
{
    public async Task<IEnumerable<Material>> ObterMateriaisPorServicoAsync(Guid servicoId)
    {
        return await _dbSet
            .Where(m => m.Servicos.Any(s => s.Id == servicoId))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Material?> ObterPorCodigoAsync(string codigo)
    {
        return await _dbSet.FirstOrDefaultAsync(m => m.Codigo == codigo);
    }
}
