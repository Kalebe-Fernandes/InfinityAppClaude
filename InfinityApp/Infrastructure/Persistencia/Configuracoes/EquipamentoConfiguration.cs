using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Comum;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração EF Core para a entidade Equipamento.
/// </summary>
public class EquipamentoConfiguration : IEntityTypeConfiguration<Equipamento>
{
    public void Configure(EntityTypeBuilder<Equipamento> builder)
    {
        builder.ToTable("Equipamentos");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Codigo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Descricao)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Tipo)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(e => e.Placa)
            .HasMaxLength(20);

        builder.Property(e => e.Provisorio)
            .IsRequired();

        // Índices
        builder.HasIndex(e => e.Placa);
        builder.HasIndex(e => e.Tipo);
        builder.HasIndex(e => e.Provisorio);
        builder.HasIndex(e => e.ObraId);
    }
}
