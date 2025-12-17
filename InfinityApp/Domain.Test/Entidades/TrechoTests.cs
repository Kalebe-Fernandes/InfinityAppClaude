using Domain.Entidades.Comum;
using Domain.Enums;
using FluentAssertions;

namespace Domain.Test.Entidades;

/// <summary>
/// Testes unitários para a entidade Trecho.
/// </summary>
public class TrechoTests
{
    [Fact]
    public void Construtor_DeveCriarTrechoComIdEDatas()
    {
        // Arrange & Act
        var trecho = new Trecho();

        // Assert
        trecho.Id.Should().NotBeEmpty();
        trecho.DataCriacao.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        trecho.DataAtualizacao.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void Trecho_ComPistaDupla_DeveArmazenarCorretamente()
    {
        // Arrange
        var trecho = new Trecho
        {
            Codigo = "TR001",
            Descricao = "Trecho Norte",
            Tipo = TipoReferencia.Estaca,
            PistaDupla = true,
            EstacaInicial = 100m,
            EstacaFinal = 200m
        };

        // Assert
        trecho.PistaDupla.Should().BeTrue();
        trecho.Codigo.Should().Be("TR001");
        trecho.Descricao.Should().Be("Trecho Norte");
    }

    [Fact]
    public void Trecho_ComPistaSimples_DeveArmazenarCorretamente()
    {
        // Arrange
        var trecho = new Trecho
        {
            Codigo = "TR002",
            Descricao = "Trecho Sul",
            Tipo = TipoReferencia.Estaca,
            PistaDupla = false,
            EstacaInicial = 50m,
            EstacaFinal = 150m
        };

        // Assert
        trecho.PistaDupla.Should().BeFalse();
    }

    [Theory]
    [InlineData(TipoReferencia.Estaca)]
    [InlineData(TipoReferencia.Quilometro)]
    public void Trecho_ComDiferentesTipos_DeveArmazenarCorretamente(TipoReferencia tipo)
    {
        // Arrange & Act
        var trecho = new Trecho
        {
            Codigo = "TR003",
            Descricao = "Trecho Teste",
            Tipo = tipo
        };

        // Assert
        trecho.Tipo.Should().Be(tipo);
    }

    [Fact]
    public void ObterExtensao_ComEstacasValidas_DeveCalcularCorretamente()
    {
        // Arrange
        var trecho = new Trecho
        {
            EstacaInicial = 100m,
            EstacaFinal = 200m
        };

        // Act
        var extensao = trecho.ObterExtensao();

        // Assert
        extensao.Should().Be(100m);
    }

    [Fact]
    public void ObterExtensao_ComEstacasDecimais_DeveCalcularCorretamente()
    {
        // Arrange
        var trecho = new Trecho
        {
            EstacaInicial = 10.5m,
            EstacaFinal = 25.75m
        };

        // Act
        var extensao = trecho.ObterExtensao();

        // Assert
        extensao.Should().Be(15.25m);
    }

    [Fact]
    public void ObterExtensao_SemEstacas_DeveRetornarZero()
    {
        // Arrange
        var trecho = new Trecho();

        // Act
        var extensao = trecho.ObterExtensao();

        // Assert
        extensao.Should().Be(0m);
    }

    [Fact]
    public void EstaAtivo_ComObraAtiva_DeveRetornarTrue()
    {
        // Arrange
        var obra = new Obra
        {
            Ativa = true,
            DataInicio = DateTime.UtcNow.AddDays(-10),
            DataFim = DateTime.UtcNow.AddDays(10)
        };

        var trecho = new Trecho
        {
            Obra = obra
        };

        // Act
        var resultado = trecho.EstaAtivoComObraAtiva();

        // Assert
        resultado.Should().BeTrue();
    }

    [Fact]
    public void EstaAtivo_ComObraInativa_DeveRetornarFalse()
    {
        // Arrange
        var obra = new Obra
        {
            Ativa = false
        };

        var trecho = new Trecho
        {
            Obra = obra
        };

        // Act
        var resultado = trecho.EstaAtivoComObraAtiva();

        // Assert
        resultado.Should().BeFalse();
    }

    [Fact]
    public void EstaAtivo_SemObra_DeveRetornarTrue()
    {
        // Arrange
        var trecho = new Trecho();

        // Act
        var resultado = trecho.EstaAtivoComObraAtiva();

        // Assert
        resultado.Should().BeTrue();
    }
}
