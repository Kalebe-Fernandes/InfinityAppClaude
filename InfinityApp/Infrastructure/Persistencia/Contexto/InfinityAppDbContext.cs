using Microsoft.EntityFrameworkCore;
using Domain.Entidades.Fichas;
using Domain.Entidades.Sincronizacao;
using Domain.Entidades.Apontamentos;
using Domain.Entidades.Comum;

namespace Infrastructure.Persistencia.Contexto;

/// <summary>
/// Contexto do banco de dados do InfinityApp.
/// Gerencia todas as entidades do sistema usando Entity Framework Core com SQLite.
/// </summary>
public class InfinityAppDbContext(DbContextOptions<InfinityAppDbContext> options) : DbContext(options)
{

    // Entidades Comuns
    public DbSet<Obra> Obras => Set<Obra>();
    public DbSet<Servico> Servicos => Set<Servico>();
    public DbSet<Trecho> Trechos => Set<Trecho>();
    public DbSet<Material> Materiais => Set<Material>();
    public DbSet<Equipamento> Equipamentos => Set<Equipamento>();
    public DbSet<Deposito> Depositos => Set<Deposito>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();

    // Fichas
    public DbSet<FichaLimpezaPista> FichasLimpezaPista => Set<FichaLimpezaPista>();
    public DbSet<FichaViagemCB> FichasViagemCB => Set<FichaViagemCB>();
    public DbSet<FichaBotaDentro> FichasBotaDentro => Set<FichaBotaDentro>();
    public DbSet<FichaFresagem> FichasFresagem => Set<FichaFresagem>();
    public DbSet<FichaCBUQ> FichasCBUQ => Set<FichaCBUQ>();
    public DbSet<FichaMicrorevestimento> FichasMicrorevestimento => Set<FichaMicrorevestimento>();

    // Apontamentos
    public DbSet<ApontamentoLimpezaPista> ApontamentosLimpezaPista => Set<ApontamentoLimpezaPista>();
    public DbSet<ApontamentoViagemCB> ApontamentosViagemCB => Set<ApontamentoViagemCB>();
    public DbSet<ApontamentoBotaDentro> ApontamentosBotaDentro => Set<ApontamentoBotaDentro>();
    public DbSet<ApontamentoFresagem> ApontamentosFresagem => Set<ApontamentoFresagem>();
    public DbSet<ApontamentoCBUQ> ApontamentosCBUQ => Set<ApontamentoCBUQ>();
    public DbSet<ApontamentoMicrorevestimento> ApontamentosMicrorevestimento => Set<ApontamentoMicrorevestimento>();

    // Entidades Associativas
    public DbSet<FichaEquipamento> FichasEquipamentos => Set<FichaEquipamento>();
    public DbSet<ApontamentoCBUQMaterial> ApontamentosCBUQMateriais => Set<ApontamentoCBUQMaterial>();
    public DbSet<ApontamentoMicrorevestimentoMaterial> ApontamentosMicrorevestimentoMateriais => Set<ApontamentoMicrorevestimentoMaterial>();

    // Sincronização
    public DbSet<FilaSincronizacao> FilaSincronizacao => Set<FilaSincronizacao>();
    public DbSet<HistoricoSincronizacao> HistoricoSincronizacao => Set<HistoricoSincronizacao>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplicar todas as configurações do assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfinityAppDbContext).Assembly);

        // Configurações globais
        ConfigurarConvencoesGlobais(modelBuilder);
    }

    /// <summary>
    /// Configura convenções globais para todas as entidades.
    /// </summary>
    private void ConfigurarConvencoesGlobais(ModelBuilder modelBuilder)
    {
        // Desabilitar cascata de exclusão por padrão
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        // Configurar precisão de decimais
        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetPrecision(18);
            property.SetScale(2);
        }

        // Configurar tamanho padrão de strings
        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(string)))
        {
            if (property.GetMaxLength() == null)
            {
                property.SetMaxLength(500);
            }
        }
    }

    /// <summary>
    /// Sobrescreve SaveChanges para atualizar automaticamente DataAtualizacao.
    /// </summary>
    public override int SaveChanges()
    {
        AtualizarDataAtualizacao();
        return base.SaveChanges();
    }

    /// <summary>
    /// Sobrescreve SaveChangesAsync para atualizar automaticamente DataAtualizacao.
    /// </summary>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AtualizarDataAtualizacao();
        return base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Atualiza a propriedade DataAtualizacao de entidades modificadas.
    /// </summary>
    private void AtualizarDataAtualizacao()
    {
        var entradas = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified)
            .Select(e => e.Entity);

        foreach (var entidade in entradas)
        {
            if (entidade is Domain.Entidades.Base.EntidadeBase entidadeBase)
            {
                entidadeBase.AtualizarDataAtualizacao();
            }
        }
    }
}
