using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Fichas;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para FichaBotaDentro.
/// </summary>
public class FichaBotaDentroConfiguration : FichaBaseConfiguration<FichaBotaDentro>
{
    public override void Configure(EntityTypeBuilder<FichaBotaDentro> builder)
    {
        base.Configure(builder);

        builder.ToTable("FichasBotaDentro");

        builder.HasOne(f => f.DepositoOrigem)
            .WithMany()
            .HasForeignKey(f => f.DepositoOrigemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.DepositoDestino)
            .WithMany()
            .HasForeignKey(f => f.DepositoDestinoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(f => f.Apontamentos)
            .WithOne(a => a.FichaBotaDentro)
            .HasForeignKey(a => a.FichaBotaDentroId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
