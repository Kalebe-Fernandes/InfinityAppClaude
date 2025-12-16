using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Apontamentos;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para ApontamentoMicrorevestimento.
/// </summary>
public class ApontamentoMicrorevestimentoConfiguration : IEntityTypeConfiguration<ApontamentoMicrorevestimento>
{
    public void Configure(EntityTypeBuilder<ApontamentoMicrorevestimento> builder)
    {
        builder.ToTable("ApontamentosMicrorevestimento");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Lado)
            .IsRequired()
            .HasConversion<string>();

        builder.HasMany(a => a.Materiais)
            .WithOne(m => m.ApontamentoMicrorevestimento)
            .HasForeignKey(m => m.ApontamentoMicrorevestimentoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(a => a.FichaMicrorevestimentoId);
    }
}
