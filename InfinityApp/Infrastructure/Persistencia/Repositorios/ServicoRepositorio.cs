using Microsoft.EntityFrameworkCore;
using Domain.Entidades.Comum;
using Domain.Interfaces.Repositorios;
using Infrastructure.Persistencia.Contexto;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Implementação do repositório de Serviços.
/// </summary>
public class ServicoRepositorio(InfinityAppDbContext contexto) : RepositorioBase<Servico>(contexto), IServicoRepositorio
{
    public async Task<IEnumerable<Servico>> ObterServicosAtivosAsync()
    {
        return await _dbSet
            .Where(s => s.Ativo)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Servico>> ObterServicosPorObraAsync(Guid obraId)
    {
        return await _dbSet
            .Where(s => s.ObraId == obraId && s.Ativo)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Servico?> ObterPorCodigoAsync(string codigo)
    {
        return await _dbSet.FirstOrDefaultAsync(s => s.Codigo == codigo);
    }
}
