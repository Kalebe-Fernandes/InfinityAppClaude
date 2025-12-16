using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Fichas;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para FichaMicrorevestimento.
/// </summary>
public class FichaMicrorevestimentoConfiguration : FichaBaseConfiguration<FichaMicrorevestimento>
{
    public override void Configure(EntityTypeBuilder<FichaMicrorevestimento> builder)
    {
        base.Configure(builder);

        builder.ToTable("FichasMicrorevestimento");

        builder.HasMany(f => f.Apontamentos)
            .WithOne(a => a.FichaMicrorevestimento)
            .HasForeignKey(a => a.FichaMicrorevestimentoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
