using Microsoft.EntityFrameworkCore;
using Domain.Entidades.Comum;
using Domain.Interfaces.Repositorios;
using Infrastructure.Persistencia.Contexto;
using Domain.Enums;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Implementação do repositório de Equipamentos.
/// </summary>
public class EquipamentoRepositorio(InfinityAppDbContext contexto) : RepositorioBase<Equipamento>(contexto), IEquipamentoRepositorio
{
    public async Task<IEnumerable<Equipamento>> ObterEquipamentosPorObraAsync(Guid obraId)
    {
        return await _dbSet
            .Where(e => e.ObraId == obraId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Equipamento>> ObterEquipamentosPorTipoAsync(TipoEquipamento tipo, Guid obraId)
    {
        return await _dbSet
            .Where(e => e.ObraId == obraId && e.Tipo == tipo)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Equipamento>> ObterEquipamentosProvisorioAsync()
    {
        return await _dbSet
            .Where(e => e.Provisorio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Equipamento?> ObterPorPlacaAsync(string placa)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Placa == placa);
    }
}
