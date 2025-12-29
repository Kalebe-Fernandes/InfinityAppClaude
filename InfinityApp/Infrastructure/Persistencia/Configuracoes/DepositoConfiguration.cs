using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Comum;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração EF Core para a entidade Deposito.
/// </summary>
public class DepositoConfiguration : IEntityTypeConfiguration<Deposito>
{
    public void Configure(EntityTypeBuilder<Deposito> builder)
    {
        builder.ToTable("Depositos");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Codigo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(d => d.Nome)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(d => d.Provisorio)
            .IsRequired();

        // Value Object Coordenada
        builder.OwnsOne(d => d.Coordenada, coordenada =>
        {
            coordenada.Property(c => c.Latitude)
                .HasColumnName("Latitude")
                .HasPrecision(10, 6);

            coordenada.Property(c => c.Longitude)
                .HasColumnName("Longitude")
                .HasPrecision(10, 6);
        });

        // Índices
        builder.HasIndex(d => d.Codigo);
        builder.HasIndex(d => d.Provisorio);
        builder.HasIndex(d => d.ObraId);
    }
}
