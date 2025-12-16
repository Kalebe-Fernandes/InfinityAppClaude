using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Fichas;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para FichaViagemCB.
/// </summary>
public class FichaViagemCBConfiguration : FichaBaseConfiguration<FichaViagemCB>
{
    public override void Configure(EntityTypeBuilder<FichaViagemCB> builder)
    {
        base.Configure(builder);

        builder.ToTable("FichasViagemCB");

        builder.Property(f => f.Capacidade)
            .IsRequired();

        builder.HasOne(f => f.DepositoOrigem)
            .WithMany()
            .HasForeignKey(f => f.DepositoOrigemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.DepositoDestino)
            .WithMany()
            .HasForeignKey(f => f.DepositoDestinoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(f => f.Equipamentos)
            .WithOne(e => e.FichaViagemCB)
            .HasForeignKey(e => e.FichaViagemCBId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.Apontamentos)
            .WithOne(a => a.FichaViagemCB)
            .HasForeignKey(a => a.FichaViagemCBId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
