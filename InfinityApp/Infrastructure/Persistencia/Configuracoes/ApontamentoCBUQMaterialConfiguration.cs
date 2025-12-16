using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Apontamentos;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para ApontamentoCBUQMaterial (entidade associativa).
/// </summary>
public class ApontamentoCBUQMaterialConfiguration : IEntityTypeConfiguration<ApontamentoCBUQMaterial>
{
    public void Configure(EntityTypeBuilder<ApontamentoCBUQMaterial> builder)
    {
        builder.ToTable("ApontamentosCBUQMateriais");

        builder.HasKey(am => am.Id);

        builder.HasOne(am => am.Material)
            .WithMany()
            .HasForeignKey(am => am.MaterialId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(am => new { am.ApontamentoCBUQId, am.MaterialId });
    }
}
