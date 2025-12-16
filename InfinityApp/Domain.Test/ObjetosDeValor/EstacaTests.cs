using Domain.ObjetosDeValor;
using FluentAssertions;

namespace Domain.Test.ObjetosDeValor;

/// <summary>
/// Testes unitários para o Value Object Estaca.
/// </summary>
public class EstacaTests
{
    [Fact]
    public void Criar_ComValoresValidos_DeveCriarEstaca()
    {
        // Arrange & Act
        var estaca = Estaca.Criar(10, 5.50m);

        // Assert
        estaca.Should().NotBeNull();
        estaca.Numero.Should().Be(10);
        estaca.Fracao.Should().Be(5.50m);
    }

    [Fact]
    public void Criar_ComNumeroNegativo_DeveLancarExcecao()
    {
        // Arrange & Act
        Action acao = () => Estaca.Criar(-1, 5.50m);

        // Assert
        acao.Should().Throw<ArgumentException>()
            .WithMessage("*número da estaca deve ser maior ou igual a zero*");
    }

    [Fact]
    public void Criar_ComFracaoNegativa_DeveLancarExcecao()
    {
        // Arrange & Act
        Action acao = () => Estaca.Criar(10, -1m);

        // Assert
        acao.Should().Throw<ArgumentException>()
            .WithMessage("*fração da estaca deve estar entre 0.00 e 19.99*");
    }

    [Fact]
    public void Criar_ComFracaoMaiorQue20_DeveLancarExcecao()
    {
        // Arrange & Act
        Action acao = () => Estaca.Criar(10, 20m);

        // Assert
        acao.Should().Throw<ArgumentException>()
            .WithMessage("*fração da estaca deve estar entre 0.00 e 19.99*");
    }

    [Fact]
    public void ParaMetros_DeveConverterCorretamente()
    {
        // Arrange
        var estaca = Estaca.Criar(10, 5.50m);

        // Act
        var metros = estaca.ParaMetros();

        // Assert
        metros.Should().Be(205.50m); // (10 * 20) + 5.50
    }

    [Fact]
    public void ToString_DeveFormatarCorretamente()
    {
        // Arrange
        var estaca = Estaca.Criar(10, 5.50m);

        // Act
        var texto = estaca.ToString();

        // Assert
        texto.Should().Be("10+5.50");
    }

    [Fact]
    public void Equals_ComEstacasIguais_DeveRetornarTrue()
    {
        // Arrange
        var estaca1 = Estaca.Criar(10, 5.50m);
        var estaca2 = Estaca.Criar(10, 5.50m);

        // Act & Assert
        estaca1.Should().Be(estaca2);
        (estaca1 == estaca2).Should().BeTrue();
    }

    [Fact]
    public void Equals_ComEstacasDiferentes_DeveRetornarFalse()
    {
        // Arrange
        var estaca1 = Estaca.Criar(10, 5.50m);
        var estaca2 = Estaca.Criar(11, 5.50m);

        // Act & Assert
        estaca1.Should().NotBe(estaca2);
        (estaca1 != estaca2).Should().BeTrue();
    }

    [Fact]
    public void OperadorMaiorQue_DeveCompararCorretamente()
    {
        // Arrange
        var estaca1 = Estaca.Criar(10, 5.50m);
        var estaca2 = Estaca.Criar(9, 15.00m);

        // Act & Assert
        (estaca1 > estaca2).Should().BeTrue();
        (estaca2 < estaca1).Should().BeTrue();
    }

    [Fact]
    public void OperadorMenorQue_DeveCompararCorretamente()
    {
        // Arrange
        var estaca1 = Estaca.Criar(10, 5.50m);
        var estaca2 = Estaca.Criar(11, 15.00m);

        // Act & Assert
        (estaca1 < estaca2).Should().BeTrue();
        (estaca2 > estaca1).Should().BeTrue();
    }

    [Fact]
    public void OperadorMaiorOuIgual_DeveCompararCorretamente()
    {
        // Arrange
        var estaca1 = Estaca.Criar(10, 5.50m);
        var estaca2 = Estaca.Criar(10, 5.50m);
        var estaca3 = Estaca.Criar(9, 15.00m);

        // Act & Assert
        (estaca1 >= estaca2).Should().BeTrue();
        (estaca1 >= estaca3).Should().BeTrue();
    }

    [Fact]
    public void OperadorMenorOuIgual_DeveCompararCorretamente()
    {
        // Arrange
        var estaca1 = Estaca.Criar(10, 5.50m);
        var estaca2 = Estaca.Criar(10, 5.50m);
        var estaca3 = Estaca.Criar(11, 15.00m);

        // Act & Assert
        (estaca1 <= estaca2).Should().BeTrue();
        (estaca1 <= estaca3).Should().BeTrue();
    }
}
