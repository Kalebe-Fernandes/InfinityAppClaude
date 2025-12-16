using Domain.Entidades.Sincronizacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para FilaSincronizacao.
/// </summary>
public class FilaSincronizacaoConfiguration : IEntityTypeConfiguration<FilaSincronizacao>
{
    public void Configure(EntityTypeBuilder<FilaSincronizacao> builder)
    {
        builder.ToTable("FilaSincronizacao");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.FichaId)
            .IsRequired();

        builder.Property(f => f.TipoFicha)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(f => f.TipoOperacao)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(f => f.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(f => f.MensagemErro)
            .HasMaxLength(2000);

        builder.HasIndex(f => f.Status);
        builder.HasIndex(f => f.FichaId);
        builder.HasIndex(f => f.DataSincronizacao);
    }
}
