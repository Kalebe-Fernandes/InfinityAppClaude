using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositorios;
using Domain.Entidades.Base;
using Infrastructure.Persistencia.Contexto;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Implementação genérica do repositório base.
/// Fornece operações CRUD básicas para todas as entidades.
/// </summary>
public class RepositorioBase<T>(InfinityAppDbContext contexto) : IRepositorio<T> where T : EntidadeBase
{
    protected readonly InfinityAppDbContext _contexto = contexto;
    protected readonly DbSet<T> _dbSet = contexto.Set<T>();

    public virtual async Task<T?> ObterPorIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> ObterTodosAsync()
    {
        return await _dbSet
            .AsNoTracking()
            .ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicado)
    {
        return await _dbSet
            .Where(predicado)
            .AsNoTracking()
            .ToListAsync();
    }

    public virtual async Task AdicionarAsync(T entidade)
    {
        await _dbSet.AddAsync(entidade);
    }

    public virtual async Task AdicionarVariasAsync(IEnumerable<T> entidades)
    {
        await _dbSet.AddRangeAsync(entidades);
    }

    public virtual void Atualizar(T entidade)
    {
        _dbSet.Update(entidade);
    }

    public virtual void Remover(T entidade)
    {
        _dbSet.Remove(entidade);
    }

    public virtual void RemoverVarias(IEnumerable<T> entidades)
    {
        _dbSet.RemoveRange(entidades);
    }

    public virtual async Task<bool> ExisteAsync(Expression<Func<T, bool>> predicado)
    {
        return await _dbSet.AnyAsync(predicado);
    }

    public virtual async Task<int> ContarAsync(Expression<Func<T, bool>> predicado)
    {
        return await _dbSet.CountAsync(predicado);
    }
}
