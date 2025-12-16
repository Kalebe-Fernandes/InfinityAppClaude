using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Apontamentos;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para ApontamentoLimpezaPista.
/// </summary>
public class ApontamentoLimpezaPistaConfiguration : IEntityTypeConfiguration<ApontamentoLimpezaPista>
{
    public void Configure(EntityTypeBuilder<ApontamentoLimpezaPista> builder)
    {
        builder.ToTable("ApontamentosLimpezaPista");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Lado)
            .IsRequired()
            .HasConversion<string>();

        builder.HasIndex(a => a.FichaLimpezaPistaId);
    }
}
