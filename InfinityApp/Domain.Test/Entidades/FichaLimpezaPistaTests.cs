using FluentAssertions;
using Domain.Entidades.Fichas;
using Domain.Enums;
using Domain.Entidades.Apontamentos;

namespace Domain.Test.Entidades;

/// <summary>
/// Testes unitários para a entidade FichaLimpezaPista.
/// </summary>
public class FichaLimpezaPistaTests
{
    [Fact]
    public void Construtor_DeveCriarFichaComIdEDatas()
    {
        // Arrange & Act
        var ficha = new FichaLimpezaPista();

        // Assert
        ficha.Id.Should().NotBeEmpty();
        ficha.DataCriacao.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        ficha.DataAtualizacao.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        ficha.Status.Should().Be(StatusFicha.Pendente);
        ficha.Apontamentos.Should().NotBeNull();
        ficha.Apontamentos.Should().BeEmpty();
    }

    [Fact]
    public void AdicionarApontamento_DeveAdicionarApontamentoNaColecao()
    {
        // Arrange
        var ficha = new FichaLimpezaPista();
        var apontamento = new ApontamentoLimpezaPista
        {
            Lado = Lado.LD,
            EstacaInicial = 10,
            FracaoInicial = 0m,
            EstacaFinal = 15,
            FracaoFinal = 0m,
            Extensao = 100m,
            Largura = 3.5m,
            AreaM2 = 350m
        };

        // Act
        ficha.AdicionarApontamento(apontamento);

        // Assert
        ficha.Apontamentos.Should().HaveCount(1);
        ficha.Apontamentos.First().Should().Be(apontamento);
    }

    [Fact]
    public void RemoverUltimoApontamento_ComApontamentos_DeveRemoverUltimo()
    {
        // Arrange
        var ficha = new FichaLimpezaPista();
        var apontamento1 = new ApontamentoLimpezaPista { Lado = Lado.LD, Extensao = 100m, Largura = 3.5m, AreaM2 = 350m };
        var apontamento2 = new ApontamentoLimpezaPista { Lado = Lado.LE, Extensao = 50m, Largura = 3.5m, AreaM2 = 175m };

        ficha.AdicionarApontamento(apontamento1);
        ficha.AdicionarApontamento(apontamento2);

        // Act
        ficha.RemoverUltimoApontamento();

        // Assert
        ficha.Apontamentos.Should().HaveCount(1);
        ficha.Apontamentos.First().Should().Be(apontamento1);
    }

    [Fact]
    public void RemoverUltimoApontamento_SemApontamentos_DeveLancarExcecao()
    {
        // Arrange
        var ficha = new FichaLimpezaPista();

        // Act
        Action acao = () => ficha.RemoverUltimoApontamento();

        // Assert
        acao.Should().Throw<InvalidOperationException>().WithMessage("*não há apontamentos para remover*");
    }

    [Fact]
    public void Finalizar_FichaPendente_DeveMudarStatusParaFinalizada()
    {
        // Arrange
        var ficha = new FichaLimpezaPista
        {
            Status = StatusFicha.Pendente
        };

        // Act
        ficha.Finalizar();

        // Assert
        ficha.Status.Should().Be(StatusFicha.Finalizada);
    }

    [Fact]
    public void Finalizar_FichaSincronizada_DeveLancarExcecao()
    {
        // Arrange
        var ficha = new FichaLimpezaPista
        {
            Status = StatusFicha.Sincronizada
        };

        // Act
        Action acao = () => ficha.Finalizar();

        // Assert
        acao.Should().Throw<InvalidOperationException>()
            .WithMessage("*apenas fichas pendentes podem ser finalizadas*");
    }

    [Fact]
    public void Desfinalizar_FichaFinalizada_DeveMudarStatusParaPendente()
    {
        // Arrange
        var ficha = new FichaLimpezaPista
        {
            Status = StatusFicha.Finalizada
        };

        // Act
        ficha.Desfinalizar();

        // Assert
        ficha.Status.Should().Be(StatusFicha.Pendente);
    }

    [Fact]
    public void Desfinalizar_FichaSincronizada_DeveLancarExcecao()
    {
        // Arrange
        var ficha = new FichaLimpezaPista
        {
            Status = StatusFicha.Sincronizada
        };

        // Act
        Action acao = () => ficha.Desfinalizar();

        // Assert
        acao.Should().Throw<InvalidOperationException>()
            .WithMessage("*apenas fichas finalizadas podem ser desfinalizadas*");
    }

    [Fact]
    public void Cancelar_FichaPendenteOuFinalizada_DeveMudarStatusParaCancelada()
    {
        // Arrange
        var ficha = new FichaLimpezaPista
        {
            Status = StatusFicha.Pendente
        };

        // Act
        ficha.Cancelar();

        // Assert
        ficha.Status.Should().Be(StatusFicha.Cancelada);
    }

    [Fact]
    public void PodeSerEditada_FichaPendente_DeveRetornarTrue()
    {
        // Arrange
        var ficha = new FichaLimpezaPista
        {
            Status = StatusFicha.Pendente
        };

        // Act
        var resultado = ficha.PodeSerEditada();

        // Assert
        resultado.Should().BeTrue();
    }

    [Fact]
    public void PodeSerEditada_FichaSincronizada_DeveRetornarFalse()
    {
        // Arrange
        var ficha = new FichaLimpezaPista
        {
            Status = StatusFicha.Sincronizada
        };

        // Act
        var resultado = ficha.PodeSerEditada();

        // Assert
        resultado.Should().BeFalse();
    }

    [Fact]
    public void PodeSerExcluida_FichaPendenteOuCancelada_DeveRetornarTrue()
    {
        // Arrange
        var fichaPendente = new FichaLimpezaPista { Status = StatusFicha.Pendente };
        var fichaCancelada = new FichaLimpezaPista { Status = StatusFicha.Cancelada };

        // Act & Assert
        fichaPendente.PodeSerExcluida().Should().BeTrue();
        fichaCancelada.PodeSerExcluida().Should().BeTrue();
    }

    [Fact]
    public void PodeSerExcluida_FichaSincronizada_DeveRetornarFalse()
    {
        // Arrange
        var ficha = new FichaLimpezaPista
        {
            Status = StatusFicha.Sincronizada
        };

        // Act
        var resultado = ficha.PodeSerExcluida();

        // Assert
        resultado.Should().BeFalse();
    }

    [Fact]
    public void MarcarComoSincronizada_FichaFinalizada_DeveMudarStatusParaSincronizada()
    {
        // Arrange
        var ficha = new FichaLimpezaPista
        {
            Status = StatusFicha.Finalizada
        };

        // Act
        ficha.MarcarComoSincronizada();

        // Assert
        ficha.Status.Should().Be(StatusFicha.Sincronizada);
    }
}
