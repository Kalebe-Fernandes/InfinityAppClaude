using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Comum;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração EF Core para a entidade Servico.
/// </summary>
public class ServicoConfiguration : IEntityTypeConfiguration<Servico>
{
    public void Configure(EntityTypeBuilder<Servico> builder)
    {
        builder.ToTable("Servicos");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Codigo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.Descricao)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(s => s.Unidade)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(s => s.Ativo)
            .IsRequired();

        // Índices
        builder.HasIndex(s => new { s.ObraId, s.Codigo });
        builder.HasIndex(s => s.Ativo);
    }
}
