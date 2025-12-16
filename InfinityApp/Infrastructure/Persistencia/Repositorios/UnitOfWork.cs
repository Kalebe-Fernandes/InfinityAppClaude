using Microsoft.EntityFrameworkCore.Storage;
using Domain.Interfaces.Repositorios;
using Infrastructure.Persistencia.Contexto;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Implementação do padrão Unit of Work.
/// Gerencia transações e coordena a persistência de múltiplas entidades.
/// </summary>
public class UnitOfWork(InfinityAppDbContext contexto) : IUnitOfWork
{
    private readonly InfinityAppDbContext _contexto = contexto;
    private IDbContextTransaction? _transacao;

    public async Task<int> CommitAsync()
    {
        try
        {
            return await _contexto.SaveChangesAsync();
        }
        catch
        {
            await RollbackAsync();
            throw;
        }
    }

    public async Task RollbackAsync()
    {
        if (_transacao != null)
        {
            await _transacao.RollbackAsync();
            await _transacao.DisposeAsync();
            _transacao = null;
        }

        // Desfaz todas as alterações pendentes no ChangeTracker
        foreach (var entry in _contexto.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case Microsoft.EntityFrameworkCore.EntityState.Added:
                    entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    break;
                case Microsoft.EntityFrameworkCore.EntityState.Modified:
                case Microsoft.EntityFrameworkCore.EntityState.Deleted:
                    entry.Reload();
                    break;
            }
        }
    }

    public async Task IniciarTransacaoAsync()
    {
        if (_transacao != null)
        {
            throw new InvalidOperationException("Já existe uma transação ativa.");
        }

        _transacao = await _contexto.Database.BeginTransactionAsync();
    }

    public async Task ConfirmarTransacaoAsync()
    {
        if (_transacao == null)
        {
            throw new InvalidOperationException("Não há transação ativa para confirmar.");
        }

        try
        {
            await _contexto.SaveChangesAsync();
            await _transacao.CommitAsync();
        }
        catch
        {
            await ReverterTransacaoAsync();
            throw;
        }
        finally
        {
            await _transacao.DisposeAsync();
            _transacao = null;
        }
    }

    public async Task ReverterTransacaoAsync()
    {
        if (_transacao == null)
        {
            throw new InvalidOperationException("Não há transação ativa para reverter.");
        }

        await _transacao.RollbackAsync();
        await _transacao.DisposeAsync();
        _transacao = null;
    }

    public void Dispose()
    {
        _transacao?.Dispose();
        _contexto.Dispose();
        GC.SuppressFinalize(this);
    }
}
