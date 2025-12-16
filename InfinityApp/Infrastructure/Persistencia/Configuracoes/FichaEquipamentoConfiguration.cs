using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Sincronizacao;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração para FichaEquipamento (entidade associativa).
/// </summary>
public class FichaEquipamentoConfiguration : IEntityTypeConfiguration<FichaEquipamento>
{
    public void Configure(EntityTypeBuilder<FichaEquipamento> builder)
    {
        builder.ToTable("FichasEquipamentos");

        builder.HasKey(fe => fe.Id);

        builder.HasOne(fe => fe.Equipamento)
            .WithMany()
            .HasForeignKey(fe => fe.EquipamentoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(fe => new { fe.FichaViagemCBId, fe.EquipamentoId })
            .IsUnique();
    }
}
