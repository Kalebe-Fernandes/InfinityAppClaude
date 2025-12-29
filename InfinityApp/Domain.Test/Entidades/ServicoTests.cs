using Domain.Entidades.Comum;
using FluentAssertions;

namespace Domain.Test.Entidades;

/// <summary>
/// Testes unitários para a entidade Servico.
/// </summary>
public class ServicoTests
{
    [Fact]
    public void Construtor_DeveCriarServicoComIdEDatas()
    {
        // Arrange & Act
        var servico = new Servico();

        // Assert
        servico.Id.Should().NotBeEmpty();
        servico.DataCriacao.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        servico.DataAtualizacao.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        servico.Ativo.Should().BeTrue();
    }

    [Fact]
    public void Servico_ComDadosCompletos_DeveArmazenarCorretamente()
    {
        // Arrange
        var obraId = Guid.NewGuid();
        var servico = new Servico
        {
            Codigo = "SRV001",
            Nome = "Limpeza de Pista",
            UnidadeMedida = "m²",
            ObraId = obraId,
            Ativo = true
        };

        // Assert
        servico.Codigo.Should().Be("SRV001");
        servico.Nome.Should().Be("Limpeza de Pista");
        servico.UnidadeMedida.Should().Be("m²");
        servico.ObraId.Should().Be(obraId);
        servico.Ativo.Should().BeTrue();
    }

    [Fact]
    public void Ativar_ServicoInativo_DeveAtivarServico()
    {
        // Arrange
        var servico = new Servico { Ativo = false };

        // Act
        servico.Ativar();

        // Assert
        servico.Ativo.Should().BeTrue();
    }

    [Fact]
    public void Desativar_ServicoAtivo_DeveDesativarServico()
    {
        // Arrange
        var servico = new Servico { Ativo = true };

        // Act
        servico.Desativar();

        // Assert
        servico.Ativo.Should().BeFalse();
    }

    [Theory]
    [InlineData("m²", "metros quadrados")]
    [InlineData("m³", "metros cúbicos")]
    [InlineData("m", "metros")]
    [InlineData("un", "unidade")]
    [InlineData("kg", "quilogramas")]
    public void Servico_ComDiferentesUnidades_DeveArmazenarCorretamente(string unidade, string descricao)
    {
        // Arrange & Act
        var servico = new Servico
        {
            Codigo = "SRV001",
            Nome = descricao,
            UnidadeMedida = unidade
        };

        // Assert
        servico.UnidadeMedida.Should().Be(unidade);
    }

    [Fact]
    public void AtualizarDataAtualizacao_DeveAtualizarDataCorretamente()
    {
        // Arrange
        var servico = new Servico();
        var dataAnterior = servico.DataAtualizacao;
        Thread.Sleep(10);

        // Act
        servico.AtualizarDataAtualizacao();

        // Assert
        servico.DataAtualizacao.Should().BeAfter(dataAnterior);
    }

    [Fact]
    public void Equals_ComServicosIguais_DeveRetornarTrue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var servico1 = new Servico { Id = id };
        var servico2 = new Servico { Id = id };

        // Act & Assert
        servico1.Should().Be(servico2);
        (servico1 == servico2).Should().BeTrue();
    }

    [Fact]
    public void Equals_ComServicosDiferentes_DeveRetornarFalse()
    {
        // Arrange
        var servico1 = new Servico { Id = Guid.NewGuid() };
        var servico2 = new Servico { Id = Guid.NewGuid() };

        // Act & Assert
        servico1.Should().NotBe(servico2);
        (servico1 != servico2).Should().BeTrue();
    }
}
