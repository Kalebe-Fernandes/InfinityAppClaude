using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Apontamentos;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para ApontamentoViagemCB.
/// </summary>
public class ApontamentoViagemCBConfiguration : IEntityTypeConfiguration<ApontamentoViagemCB>
{
    public void Configure(EntityTypeBuilder<ApontamentoViagemCB> builder)
    {
        builder.ToTable("ApontamentosViagemCB");

        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Equipamento)
            .WithMany()
            .HasForeignKey(a => a.EquipamentoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Material)
            .WithMany()
            .HasForeignKey(a => a.MaterialId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(a => a.FichaViagemCBId);
        builder.HasIndex(a => a.EquipamentoId);
    }
}
