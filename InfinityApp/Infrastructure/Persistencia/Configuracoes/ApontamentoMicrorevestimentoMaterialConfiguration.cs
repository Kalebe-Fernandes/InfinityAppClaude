using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Apontamentos;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para ApontamentoMicrorevestimentoMaterial (entidade associativa).
/// </summary>
public class ApontamentoMicrorevestimentoMaterialConfiguration : IEntityTypeConfiguration<ApontamentoMicrorevestimentoMaterial>
{
    public void Configure(EntityTypeBuilder<ApontamentoMicrorevestimentoMaterial> builder)
    {
        builder.ToTable("ApontamentosMicrorevestimentoMateriais");

        builder.HasKey(am => am.Id);

        builder.HasOne(am => am.Material)
            .WithMany()
            .HasForeignKey(am => am.MaterialId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(am => new { am.ApontamentoMicrorevestimentoId, am.MaterialId });
    }
}
