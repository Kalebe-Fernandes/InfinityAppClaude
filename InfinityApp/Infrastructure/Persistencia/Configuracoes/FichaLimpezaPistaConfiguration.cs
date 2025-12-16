using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Fichas;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para FichaLimpezaPista.
/// </summary>
public class FichaLimpezaPistaConfiguration : FichaBaseConfiguration<FichaLimpezaPista>
{
    public override void Configure(EntityTypeBuilder<FichaLimpezaPista> builder)
    {
        base.Configure(builder);

        builder.ToTable("FichasLimpezaPista");

        builder.HasMany(f => f.Apontamentos)
            .WithOne(a => a.FichaLimpezaPista)
            .HasForeignKey(a => a.FichaLimpezaPistaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
