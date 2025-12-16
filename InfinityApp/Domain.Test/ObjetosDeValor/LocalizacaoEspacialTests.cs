using Domain.Enums;
using Domain.ObjetosDeValor;
using FluentAssertions;

namespace Domain.Test.ObjetosDeValor;

/// <summary>
/// Testes unitários para o Value Object LocalizacaoEspacial.
/// </summary>
public class LocalizacaoEspacialTests
{
    [Fact]
    public void Criar_ComEstacasValidas_DeveCriarLocalizacao()
    {
        // Arrange
        var estacaInicial = Estaca.Criar(10, 5.50m);
        var estacaFinal = Estaca.Criar(15, 10.00m);

        // Act
        var localizacao = LocalizacaoEspacial.Criar(estacaInicial, estacaFinal, Lado.LD);

        // Assert
        localizacao.Should().NotBeNull();
        localizacao.EstacaInicial.Should().Be(estacaInicial);
        localizacao.EstacaFinal.Should().Be(estacaFinal);
        localizacao.Lado.Should().Be(Lado.LD);
    }

    [Fact]
    public void Criar_ComEstacaInicialMaiorQueFinal_DeveLancarExcecao()
    {
        // Arrange
        var estacaInicial = Estaca.Criar(15, 10.00m);
        var estacaFinal = Estaca.Criar(10, 5.50m);

        // Act
        Action acao = () => LocalizacaoEspacial.Criar(estacaInicial, estacaFinal, Lado.LD);

        // Assert
        acao.Should().Throw<ArgumentException>()
            .WithMessage("*estaca inicial deve ser menor que a estaca final*");
    }

    [Fact]
    public void ObterExtensao_DeveCalcularCorretamente()
    {
        // Arrange
        var estacaInicial = Estaca.Criar(10, 0m);    // 200 metros
        var estacaFinal = Estaca.Criar(15, 0m);      // 300 metros
        var localizacao = LocalizacaoEspacial.Criar(estacaInicial, estacaFinal, Lado.LD);

        // Act
        var extensao = localizacao.ObterExtensao();

        // Assert
        extensao.Should().Be(100m); // 300 - 200 = 100 metros
    }

    [Fact]
    public void ObterExtensao_ComFracoes_DeveCalcularCorretamente()
    {
        // Arrange
        var estacaInicial = Estaca.Criar(10, 5.50m);  // 205.50 metros
        var estacaFinal = Estaca.Criar(12, 15.00m);   // 255.00 metros
        var localizacao = LocalizacaoEspacial.Criar(estacaInicial, estacaFinal, Lado.LD);

        // Act
        var extensao = localizacao.ObterExtensao();

        // Assert
        extensao.Should().Be(49.50m); // 255.00 - 205.50 = 49.50 metros
    }

    [Fact]
    public void Equals_ComLocalizacoesIguais_DeveRetornarTrue()
    {
        // Arrange
        var estacaInicial1 = Estaca.Criar(10, 5.50m);
        var estacaFinal1 = Estaca.Criar(15, 10.00m);
        var localizacao1 = LocalizacaoEspacial.Criar(estacaInicial1, estacaFinal1, Lado.LD);

        var estacaInicial2 = Estaca.Criar(10, 5.50m);
        var estacaFinal2 = Estaca.Criar(15, 10.00m);
        var localizacao2 = LocalizacaoEspacial.Criar(estacaInicial2, estacaFinal2, Lado.LD);

        // Act & Assert
        localizacao1.Should().Be(localizacao2);
        (localizacao1 == localizacao2).Should().BeTrue();
    }

    [Fact]
    public void Equals_ComLocalizacoesDiferentes_DeveRetornarFalse()
    {
        // Arrange
        var estacaInicial1 = Estaca.Criar(10, 5.50m);
        var estacaFinal1 = Estaca.Criar(15, 10.00m);
        var localizacao1 = LocalizacaoEspacial.Criar(estacaInicial1, estacaFinal1, Lado.LD);

        var estacaInicial2 = Estaca.Criar(10, 5.50m);
        var estacaFinal2 = Estaca.Criar(16, 10.00m);
        var localizacao2 = LocalizacaoEspacial.Criar(estacaInicial2, estacaFinal2, Lado.LD);

        // Act & Assert
        localizacao1.Should().NotBe(localizacao2);
        (localizacao1 != localizacao2).Should().BeTrue();
    }

    [Theory]
    [InlineData(Lado.LD)]
    [InlineData(Lado.LE)]
    [InlineData(Lado.LD_LE)]
    [InlineData(Lado.CC)]
    public void Criar_ComDiferentesLados_DeveCriarLocalizacao(Lado lado)
    {
        // Arrange
        var estacaInicial = Estaca.Criar(10, 0m);
        var estacaFinal = Estaca.Criar(15, 0m);

        // Act
        var localizacao = LocalizacaoEspacial.Criar(estacaInicial, estacaFinal, lado);

        // Assert
        localizacao.Should().NotBeNull();
        localizacao.Lado.Should().Be(lado);
    }
}
