using Domain.Entidades.Comum;
using Domain.Enums;
using FluentAssertions;

namespace Domain.Test.Entidades;

/// <summary>
/// Testes unitários para a entidade Equipamento.
/// </summary>
public class EquipamentoTests
{
    [Fact]
    public void Construtor_DeveCriarEquipamentoComIdEDatas()
    {
        // Arrange & Act
        var equipamento = new Equipamento();

        // Assert
        equipamento.Id.Should().NotBeEmpty();
        equipamento.DataCriacao.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        equipamento.DataAtualizacao.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void PodeExecutar_ComTipoExecucao_DeveRetornarTrue()
    {
        // Arrange
        var equipamento = new Equipamento
        {
            Tipo = TipoEquipamento.Execucao
        };

        // Act
        var resultado = equipamento.PodeExecutar();

        // Assert
        resultado.Should().BeTrue();
    }

    [Fact]
    public void PodeExecutar_ComTipoAmbos_DeveRetornarTrue()
    {
        // Arrange
        var equipamento = new Equipamento
        {
            Tipo = TipoEquipamento.Ambos
        };

        // Act
        var resultado = equipamento.PodeExecutar();

        // Assert
        resultado.Should().BeTrue();
    }

    [Fact]
    public void PodeExecutar_ComTipoTransporte_DeveRetornarFalse()
    {
        // Arrange
        var equipamento = new Equipamento
        {
            Tipo = TipoEquipamento.Transporte
        };

        // Act
        var resultado = equipamento.PodeExecutar();

        // Assert
        resultado.Should().BeFalse();
    }

    [Fact]
    public void PodeTransportar_ComTipoTransporte_DeveRetornarTrue()
    {
        // Arrange
        var equipamento = new Equipamento
        {
            Tipo = TipoEquipamento.Transporte
        };

        // Act
        var resultado = equipamento.PodeTransportar();

        // Assert
        resultado.Should().BeTrue();
    }

    [Fact]
    public void PodeTransportar_ComTipoAmbos_DeveRetornarTrue()
    {
        // Arrange
        var equipamento = new Equipamento
        {
            Tipo = TipoEquipamento.Ambos
        };

        // Act
        var resultado = equipamento.PodeTransportar();

        // Assert
        resultado.Should().BeTrue();
    }

    [Fact]
    public void PodeTransportar_ComTipoExecucao_DeveRetornarFalse()
    {
        // Arrange
        var equipamento = new Equipamento
        {
            Tipo = TipoEquipamento.Execucao
        };

        // Act
        var resultado = equipamento.PodeTransportar();

        // Assert
        resultado.Should().BeFalse();
    }

    [Fact]
    public void MarcarComoProvisorio_DeveDefinirProvisorioComoTrue()
    {
        // Arrange
        var equipamento = new Equipamento { Provisorio = false };

        // Act
        equipamento.MarcarComoProvisorio();

        // Assert
        equipamento.Provisorio.Should().BeTrue();
    }

    [Theory]
    [InlineData(TipoEquipamento.Execucao, true, false)]
    [InlineData(TipoEquipamento.Transporte, false, true)]
    [InlineData(TipoEquipamento.Ambos, true, true)]
    public void ValidarTipoEquipamento_ComDiferentesTipos_DeveRetornarCorreto(
        TipoEquipamento tipo, 
        bool podeExecutar, 
        bool podeTransportar)
    {
        // Arrange
        var equipamento = new Equipamento { Tipo = tipo };

        // Act & Assert
        equipamento.PodeExecutar().Should().Be(podeExecutar);
        equipamento.PodeTransportar().Should().Be(podeTransportar);
    }

    [Fact]
    public void Equipamento_ComCapacidade_DeveArmazenarCorretamente()
    {
        // Arrange
        var equipamento = new Equipamento
        {
            Codigo = "EQP001",
            Descricao = "Caminhão Basculante",
            Tipo = TipoEquipamento.Transporte,
            Capacidade = 8.5m,
            Placa = "ABC-1234"
        };

        // Assert
        equipamento.Capacidade.Should().Be(8.5m);
        equipamento.Placa.Should().Be("ABC-1234");
    }

    [Fact]
    public void Equipamento_Provisorio_DeveTerObraIdNulo()
    {
        // Arrange
        var equipamento = new Equipamento
        {
            Codigo = "EQP-TEMP-001",
            Descricao = "Equipamento Temporário",
            Tipo = TipoEquipamento.Execucao,
            Provisorio = true,
            ObraId = null
        };

        // Assert
        equipamento.Provisorio.Should().BeTrue();
        equipamento.ObraId.Should().BeNull();
    }
}
