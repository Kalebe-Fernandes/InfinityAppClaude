using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades.Comum;

namespace Infrastructure.Persistencia.Configuracoes;

/// <summary>
/// Configuração EF Core para a entidade Usuario.
/// </summary>
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.KeycloakId)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Nome)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.EmailVerificado)
            .IsRequired();

        builder.Property(u => u.Ativo)
            .IsRequired();

        // Índices
        builder.HasIndex(u => u.KeycloakId)
            .IsUnique();

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.HasIndex(u => u.Username)
            .IsUnique();

        builder.HasIndex(u => u.Ativo);
    }
}
