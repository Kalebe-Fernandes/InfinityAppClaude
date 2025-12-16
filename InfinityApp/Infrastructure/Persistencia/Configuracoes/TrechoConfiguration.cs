using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Comum;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração EF Core para a entidade Trecho.
/// </summary>
public class TrechoConfiguration : IEntityTypeConfiguration<Trecho>
{
    public void Configure(EntityTypeBuilder<Trecho> builder)
    {
        builder.ToTable("Trechos");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Codigo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.Descricao)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.Tipo)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(t => t.PistaDupla)
            .IsRequired();

        // Índices
        builder.HasIndex(t => new { t.ObraId, t.Codigo });
        builder.HasIndex(t => t.PistaDupla);
    }
}
