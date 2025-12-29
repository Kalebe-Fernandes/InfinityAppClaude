using Domain.Entidades.Comum;
using FluentAssertions;

namespace Domain.Test.Entidades;

/// <summary>
/// Testes unitários para a entidade Material.
/// </summary>
public class MaterialTests
{
    [Fact]
    public void Construtor_DeveCriarMaterialComIdEDatas()
    {
        // Arrange & Act
        var material = new Material();

        // Assert
        material.Id.Should().NotBeEmpty();
        material.DataCriacao.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        material.DataAtualizacao.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void Material_ComDadosCompletos_DeveArmazenarCorretamente()
    {
        // Arrange & Act
        var material = new Material
        {
            Codigo = "MAT001",
            Descricao = "CBUQ Usinado Quente",
            UnidadeMedida = "t"
        };

        // Assert
        material.Codigo.Should().Be("MAT001");
        material.Descricao.Should().Be("CBUQ Usinado Quente");
        material.UnidadeMedida.Should().Be("t");
    }

    [Theory]
    [InlineData("t", "Tonelada")]
    [InlineData("m³", "Metro Cúbico")]
    [InlineData("kg", "Quilograma")]
    [InlineData("l", "Litro")]
    [InlineData("un", "Unidade")]
    public void Material_ComDiferentesUnidades_DeveArmazenarCorretamente(string unidade, string descricao)
    {
        // Arrange & Act
        var material = new Material
        {
            Codigo = "MAT001",
            Descricao = descricao,
            UnidadeMedida = unidade
        };

        // Assert
        material.UnidadeMedida.Should().Be(unidade);
    }

    [Fact]
    public void Equals_ComMateriaisIguais_DeveRetornarTrue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var material1 = new Material { Id = id };
        var material2 = new Material { Id = id };

        // Act & Assert
        material1.Should().Be(material2);
        (material1 == material2).Should().BeTrue();
    }

    [Fact]
    public void Equals_ComMateriaisDiferentes_DeveRetornarFalse()
    {
        // Arrange
        var material1 = new Material { Id = Guid.NewGuid() };
        var material2 = new Material { Id = Guid.NewGuid() };

        // Act & Assert
        material1.Should().NotBe(material2);
        (material1 != material2).Should().BeTrue();
    }
}
