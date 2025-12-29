using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Comum;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração EF Core para a entidade Material.
/// </summary>
public class MaterialConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.ToTable("Materiais");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Codigo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.Descricao)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.UnidadeMedida)
            .IsRequired()
            .HasMaxLength(20);

        // Índices
        builder.HasIndex(m => m.Codigo);
    }
}
