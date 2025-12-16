using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Fichas;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para FichaFresagem.
/// </summary>
public class FichaFresagemConfiguration : FichaBaseConfiguration<FichaFresagem>
{
    public override void Configure(EntityTypeBuilder<FichaFresagem> builder)
    {
        base.Configure(builder);

        builder.ToTable("FichasFresagem");

        builder.HasMany(f => f.Apontamentos)
            .WithOne(a => a.FichaFresagem)
            .HasForeignKey(a => a.FichaFresagemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
