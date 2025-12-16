using Domain.ObjetosDeValor;
using FluentAssertions;

namespace Domain.Test.ObjetosDeValor;

/// <summary>
/// Testes unitários para o Value Object Coordenada.
/// </summary>
public class CoordenadaTests
{
    [Fact]
    public void Criar_ComValoresValidos_DeveCriarCoordenada()
    {
        // Arrange & Act
        var coordenada = Coordenada.Criar(-16.6869m, -49.2648m); // Goiânia

        // Assert
        coordenada.Should().NotBeNull();
        coordenada.Latitude.Should().Be(-16.6869m);
        coordenada.Longitude.Should().Be(-49.2648m);
    }

    [Fact]
    public void Criar_ComLatitudeInvalida_DeveLancarExcecao()
    {
        // Arrange & Act
        Action acao = () => Coordenada.Criar(-91m, -49.2648m);

        // Assert
        acao.Should().Throw<ArgumentException>()
            .WithMessage("*latitude deve estar entre -90 e 90 graus*");
    }

    [Fact]
    public void Criar_ComLongitudeInvalida_DeveLancarExcecao()
    {
        // Arrange & Act
        Action acao = () => Coordenada.Criar(-16.6869m, -181m);

        // Assert
        acao.Should().Throw<ArgumentException>()
            .WithMessage("*longitude deve estar entre -180 e 180 graus*");
    }

    [Fact]
    public void ToString_DeveFormatarCorretamente()
    {
        // Arrange
        var coordenada = Coordenada.Criar(-16.686900m, -49.264800m);

        // Act
        var texto = coordenada.ToString();

        // Assert
        texto.Should().Be("-16.686900, -49.264800");
    }

    [Fact]
    public void Equals_ComCoordenadasIguais_DeveRetornarTrue()
    {
        // Arrange
        var coordenada1 = Coordenada.Criar(-16.6869m, -49.2648m);
        var coordenada2 = Coordenada.Criar(-16.6869m, -49.2648m);

        // Act & Assert
        coordenada1.Should().Be(coordenada2);
        (coordenada1 == coordenada2).Should().BeTrue();
    }

    [Fact]
    public void Equals_ComCoordenadasDiferentes_DeveRetornarFalse()
    {
        // Arrange
        var coordenada1 = Coordenada.Criar(-16.6869m, -49.2648m);
        var coordenada2 = Coordenada.Criar(-15.7801m, -47.9292m); // Brasília

        // Act & Assert
        coordenada1.Should().NotBe(coordenada2);
        (coordenada1 != coordenada2).Should().BeTrue();
    }

    [Theory]
    [InlineData(-90, -180)] // Extremos negativos
    [InlineData(90, 180)]   // Extremos positivos
    [InlineData(0, 0)]      // Zero
    [InlineData(-23.5505, -46.6333)] // São Paulo
    public void Criar_ComValoresNoLimite_DeveCriarCoordenada(decimal latitude, decimal longitude)
    {
        // Arrange & Act
        var coordenada = Coordenada.Criar(latitude, longitude);

        // Assert
        coordenada.Should().NotBeNull();
        coordenada.Latitude.Should().Be(latitude);
        coordenada.Longitude.Should().Be(longitude);
    }
}
