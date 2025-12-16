using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Fichas;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para FichaCBUQ.
/// </summary>
public class FichaCBUQConfiguration : FichaBaseConfiguration<FichaCBUQ>
{
    public override void Configure(EntityTypeBuilder<FichaCBUQ> builder)
    {
        base.Configure(builder);

        builder.ToTable("FichasCBUQ");

        builder.HasMany(f => f.Apontamentos)
            .WithOne(a => a.FichaCBUQ)
            .HasForeignKey(a => a.FichaCBUQId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
