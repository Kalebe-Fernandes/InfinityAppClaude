using Microsoft.EntityFrameworkCore;
using Domain.Entidades.Comum;
using Domain.Interfaces.Repositorios;
using Infrastructure.Persistencia.Contexto;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Implementação do repositório de Usuários.
/// </summary>
public class UsuarioRepositorio(InfinityAppDbContext contexto) : RepositorioBase<Usuario>(contexto), IUsuarioRepositorio
{
    public async Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<Usuario?> ObterPorUsernameAsync(string username)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
    }
}
