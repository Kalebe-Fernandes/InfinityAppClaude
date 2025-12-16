using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Fichas.Base;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração base para todas as fichas.
/// </summary>
public abstract class FichaBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : FichaBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Numero)
            .IsRequired();

        builder.Property(f => f.DataProducao)
            .IsRequired();

        builder.Property(f => f.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(f => f.Pista)
            .HasConversion<string>();

        builder.Property(f => f.Observacoes)
            .HasMaxLength(1000);

        // Relacionamentos comuns
        builder.HasOne(f => f.Obra)
            .WithMany()
            .HasForeignKey(f => f.ObraId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.Servico)
            .WithMany()
            .HasForeignKey(f => f.ServicoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.Trecho)
            .WithMany()
            .HasForeignKey(f => f.TrechoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.EquipamentoExecucao)
            .WithMany()
            .HasForeignKey(f => f.EquipamentoExecucaoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Índices comuns
        builder.HasIndex(f => f.ObraId);
        builder.HasIndex(f => f.Status);
        builder.HasIndex(f => f.DataProducao);
        builder.HasIndex(f => new { f.ObraId, f.Numero });
    }
}
