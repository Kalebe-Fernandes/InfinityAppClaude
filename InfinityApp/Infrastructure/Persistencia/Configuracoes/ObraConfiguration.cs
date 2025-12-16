using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Comum;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração EF Core para a entidade Obra.
/// </summary>
public class ObraConfiguration : IEntityTypeConfiguration<Obra>
{
    public void Configure(EntityTypeBuilder<Obra> builder)
    {
        builder.ToTable("Obras");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Codigo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(o => o.Nome)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(o => o.Descricao)
            .HasMaxLength(1000);

        builder.Property(o => o.DataInicio)
            .IsRequired();

        builder.Property(o => o.Ativa)
            .IsRequired();

        // Índices
        builder.HasIndex(o => o.Codigo)
            .IsUnique();

        builder.HasIndex(o => o.Ativa);

        // Relacionamentos
        builder.HasMany(o => o.Servicos)
            .WithOne(s => s.Obra)
            .HasForeignKey(s => s.ObraId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(o => o.Trechos)
            .WithOne(t => t.Obra)
            .HasForeignKey(t => t.ObraId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(o => o.Equipamentos)
            .WithOne(e => e.Obra)
            .HasForeignKey(e => e.ObraId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(o => o.Depositos)
            .WithOne(d => d.Obra)
            .HasForeignKey(d => d.ObraId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
