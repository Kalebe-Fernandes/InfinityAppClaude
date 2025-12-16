using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositorios;
using Infrastructure.Persistencia.Contexto;
using Domain.Entidades.Sincronizacao;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Implementação do repositório de Histórico de Sincronização.
/// </summary>
public class HistoricoSincronizacaoRepositorio(InfinityAppDbContext contexto) : RepositorioBase<HistoricoSincronizacao>(contexto), IHistoricoSincronizacaoRepositorio
{
    public async Task<IEnumerable<HistoricoSincronizacao>> ObterHistoricoPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
    {
        return await _dbSet
            .Where(h => h.DataInicio >= dataInicio && h.DataInicio <= dataFim)
            .OrderByDescending(h => h.DataInicio)
            .Include(h => h.Usuario)
            .Include(h => h.Obra)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<HistoricoSincronizacao>> ObterHistoricoPorUsuarioAsync(Guid usuarioId)
    {
        return await _dbSet
            .Where(h => h.UsuarioId == usuarioId)
            .OrderByDescending(h => h.DataInicio)
            .Include(h => h.Obra)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<HistoricoSincronizacao>> ObterHistoricoPorTipoAsync(string tipo)
    {
        return await _dbSet
            .Where(h => h.Tipo == tipo)
            .OrderByDescending(h => h.DataInicio)
            .Include(h => h.Usuario)
            .Include(h => h.Obra)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<HistoricoSincronizacao>> ObterUltimasSincronizacoesAsync(int quantidade)
    {
        return await _dbSet
            .OrderByDescending(h => h.DataInicio)
            .Take(quantidade)
            .Include(h => h.Usuario)
            .Include(h => h.Obra)
            .AsNoTracking()
            .ToListAsync();
    }
}
