using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositorios;
using Infrastructure.Persistencia.Contexto;
using Domain.Enums;
using Domain.Entidades.Sincronizacao;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Implementação do repositório de Fila de Sincronização.
/// </summary>
public class FilaSincronizacaoRepositorio(InfinityAppDbContext contexto) : RepositorioBase<FilaSincronizacao>(contexto), IFilaSincronizacaoRepositorio
{
    public async Task<IEnumerable<FilaSincronizacao>> ObterItensPendentesAsync()
    {
        return await _dbSet
            .Where(f => f.Status == StatusSincronizacao.Pendente || f.Status == StatusSincronizacao.Erro)
            .OrderBy(f => f.DataCriacao)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<FilaSincronizacao>> ObterItensComErroAsync()
    {
        return await _dbSet
            .Where(f => f.Status == StatusSincronizacao.Erro)
            .OrderByDescending(f => f.UltimaTentativa)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task MarcarComoSincronizadoAsync(Guid fichaId)
    {
        var item = await _dbSet.FirstOrDefaultAsync(f => f.FichaId == fichaId);
        if (item != null)
        {
            item.MarcarComoSucesso();
            await _contexto.SaveChangesAsync();
        }
    }

    public async Task MarcarComoErroAsync(Guid fichaId, string mensagemErro)
    {
        var item = await _dbSet.FirstOrDefaultAsync(f => f.FichaId == fichaId);
        if (item != null)
        {
            item.MarcarComoErro(mensagemErro);
            await _contexto.SaveChangesAsync();
        }
    }

    public async Task LimparItensAntigosAsync(int diasParaManter)
    {
        var dataLimite = DateTime.UtcNow.AddDays(-diasParaManter);

        var itensAntigos = await _dbSet
            .Where(f => f.Status == StatusSincronizacao.Sucesso && f.DataSincronizacao < dataLimite)
            .ToListAsync();

        _dbSet.RemoveRange(itensAntigos);
        await _contexto.SaveChangesAsync();
    }
}
