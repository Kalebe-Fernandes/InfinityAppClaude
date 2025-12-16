using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistencia.Contexto;

/// <summary>
/// Factory para criação do DbContext em design-time (usado para migrations).
/// </summary>
public class InfinityAppDbContextFactory : IDesignTimeDbContextFactory<InfinityAppDbContext>
{
    public InfinityAppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<InfinityAppDbContext>();
        
        // Usa um caminho padrão para design-time
        // Em produção, o caminho será configurado via dependency injection
        optionsBuilder.UseSqlite("Data Source=infinityapp.db");

        return new InfinityAppDbContext(optionsBuilder.Options);
    }
}
