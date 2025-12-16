using Domain.Entidades.Comum;
using FluentAssertions;

namespace Domain.Test.Entidades;

/// <summary>
/// Testes unitários para a entidade Obra.
/// </summary>
public class ObraTests
{
    [Fact]
    public void Construtor_DeveCriarObraComIdEDatas()
    {
        // Arrange & Act
        var obra = new Obra();

        // Assert
        obra.Id.Should().NotBeEmpty();
        obra.DataCriacao.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        obra.DataAtualizacao.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void EstaAtiva_ObraAtivaEDentroDoPeríodo_DeveRetornarTrue()
    {
        // Arrange
        var obra = new Obra
        {
            Ativa = true,
            DataInicio = DateTime.Today.AddDays(-10),
            DataFim = DateTime.Today.AddDays(10)
        };

        // Act
        var resultado = obra.EstaAtiva();

        // Assert
        resultado.Should().BeTrue();
    }

    [Fact]
    public void EstaAtiva_ObraInativa_DeveRetornarFalse()
    {
        // Arrange
        var obra = new Obra
        {
            Ativa = false,
            DataInicio = DateTime.Today.AddDays(-10),
            DataFim = DateTime.Today.AddDays(10)
        };

        // Act
        var resultado = obra.EstaAtiva();

        // Assert
        resultado.Should().BeFalse();
    }

    [Fact]
    public void EstaAtiva_ObraAtivaEAntesDaDataInicio_DeveRetornarFalse()
    {
        // Arrange
        var obra = new Obra
        {
            Ativa = true,
            DataInicio = DateTime.Today.AddDays(5),
            DataFim = DateTime.Today.AddDays(10)
        };

        // Act
        var resultado = obra.EstaAtiva();

        // Assert
        resultado.Should().BeFalse();
    }

    [Fact]
    public void EstaAtiva_ObraAtivaEAposDataFim_DeveRetornarFalse()
    {
        // Arrange
        var obra = new Obra
        {
            Ativa = true,
            DataInicio = DateTime.Today.AddDays(-10),
            DataFim = DateTime.Today.AddDays(-1)
        };

        // Act
        var resultado = obra.EstaAtiva();

        // Assert
        resultado.Should().BeFalse();
    }

    [Fact]
    public void EstaAtiva_ObraSemDataFim_DeveConsiderarApenasDataInicio()
    {
        // Arrange
        var obra = new Obra
        {
            Ativa = true,
            DataInicio = DateTime.Today.AddDays(-10),
            DataFim = null
        };

        // Act
        var resultado = obra.EstaAtiva();

        // Assert
        resultado.Should().BeTrue();
    }

    [Fact]
    public void Ativar_DeveDefinirAtivaComoTrue()
    {
        // Arrange
        var obra = new Obra { Ativa = false };

        // Act
        obra.Ativar();

        // Assert
        obra.Ativa.Should().BeTrue();
    }

    [Fact]
    public void Desativar_DeveDefinirAtivaComoFalse()
    {
        // Arrange
        var obra = new Obra { Ativa = true };

        // Act
        obra.Desativar();

        // Assert
        obra.Ativa.Should().BeFalse();
    }

    [Fact]
    public void AtualizarDataAtualizacao_DeveAtualizarData()
    {
        // Arrange
        var obra = new Obra();
        var dataAnterior = obra.DataAtualizacao;
        
        Thread.Sleep(10); // Aguarda um pouco para garantir diferença de tempo

        // Act
        obra.AtualizarDataAtualizacao();

        // Assert
        obra.DataAtualizacao.Should().BeAfter(dataAnterior);
    }

    [Fact]
    public void Equals_ComObrasComMesmoId_DeveRetornarTrue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var obra1 = new Obra { Id = id };
        var obra2 = new Obra { Id = id };

        // Act & Assert
        obra1.Should().Be(obra2);
        (obra1 == obra2).Should().BeTrue();
    }

    [Fact]
    public void Equals_ComObrasComIdsDiferentes_DeveRetornarFalse()
    {
        // Arrange
        var obra1 = new Obra { Id = Guid.NewGuid() };
        var obra2 = new Obra { Id = Guid.NewGuid() };

        // Act & Assert
        obra1.Should().NotBe(obra2);
        (obra1 != obra2).Should().BeTrue();
    }
}
