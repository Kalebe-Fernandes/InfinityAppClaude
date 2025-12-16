using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Apontamentos;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para ApontamentoBotaDentro.
/// </summary>
public class ApontamentoBotaDentroConfiguration : IEntityTypeConfiguration<ApontamentoBotaDentro>
{
    public void Configure(EntityTypeBuilder<ApontamentoBotaDentro> builder)
    {
        builder.ToTable("ApontamentosBotaDentro");

        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Material)
            .WithMany()
            .HasForeignKey(a => a.MaterialId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(a => a.FichaBotaDentroId);
    }
}
