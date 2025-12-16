using Domain.Entidades.Sincronizacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para HistoricoSincronizacao.
/// </summary>
public class HistoricoSincronizacaoConfiguration : IEntityTypeConfiguration<HistoricoSincronizacao>
{
    public void Configure(EntityTypeBuilder<HistoricoSincronizacao> builder)
    {
        builder.ToTable("HistoricoSincronizacao");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Tipo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(h => h.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(h => h.Detalhes)
            .HasMaxLength(5000);

        builder.HasOne(h => h.Usuario)
            .WithMany()
            .HasForeignKey(h => h.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(h => h.Obra)
            .WithMany()
            .HasForeignKey(h => h.ObraId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(h => h.Tipo);
        builder.HasIndex(h => h.Status);
        builder.HasIndex(h => h.DataInicio);
        builder.HasIndex(h => h.UsuarioId);
    }
}
