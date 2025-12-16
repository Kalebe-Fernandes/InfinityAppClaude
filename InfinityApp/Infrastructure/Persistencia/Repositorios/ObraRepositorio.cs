using Microsoft.EntityFrameworkCore;
using Domain.Entidades.Comum;
using Domain.Interfaces.Repositorios;
using Infrastructure.Persistencia.Contexto;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Implementação do repositório de Obras.
/// </summary>
public class ObraRepositorio(InfinityAppDbContext contexto) : RepositorioBase<Obra>(contexto), IObraRepositorio
{
    public async Task<IEnumerable<Obra>> ObterObrasAtivasAsync()
    {
        return await _dbSet
            .Where(o => o.Ativa)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Obra>> ObterObrasPorUsuarioAsync(Guid usuarioId)
    {
        // Implementação simplificada - assumindo que todas as obras estão disponíveis
        // Em produção, haveria uma tabela de relacionamento Usuario-Obra
        return await ObterObrasAtivasAsync();
    }

    public async Task<Obra?> ObterPorCodigoAsync(string codigo)
    {
        return await _dbSet.FirstOrDefaultAsync(o => o.Codigo == codigo);
    }
}
