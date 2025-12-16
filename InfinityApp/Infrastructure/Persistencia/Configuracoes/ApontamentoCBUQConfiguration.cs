using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Apontamentos;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para ApontamentoCBUQ.
/// </summary>
public class ApontamentoCBUQConfiguration : IEntityTypeConfiguration<ApontamentoCBUQ>
{
    public void Configure(EntityTypeBuilder<ApontamentoCBUQ> builder)
    {
        builder.ToTable("ApontamentosCBUQ");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Lado)
            .IsRequired()
            .HasConversion<string>();

        builder.HasMany(a => a.Materiais)
            .WithOne(m => m.ApontamentoCBUQ)
            .HasForeignKey(m => m.ApontamentoCBUQId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(a => a.FichaCBUQId);
    }
}
