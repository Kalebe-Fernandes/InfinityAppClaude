using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Apontamentos;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para ApontamentoFresagem.
/// </summary>
public class ApontamentoFresagemConfiguration : IEntityTypeConfiguration<ApontamentoFresagem>
{
    public void Configure(EntityTypeBuilder<ApontamentoFresagem> builder)
    {
        builder.ToTable("ApontamentosFresagem");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Lado)
            .IsRequired()
            .HasConversion<string>();

        builder.HasIndex(a => a.FichaFresagemId);
    }
}
