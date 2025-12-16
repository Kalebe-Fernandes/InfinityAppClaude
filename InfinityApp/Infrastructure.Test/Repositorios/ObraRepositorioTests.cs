using Domain.Entidades.Comum;
using FluentAssertions;
using Infrastructure.Persistencia.Contexto;
using Infrastructure.Persistencia.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Test.Repositorios;

/// <summary>
/// Testes unitários para ObraRepositorio.
/// Usa InMemory Database para isolar os testes.
/// </summary>
public class ObraRepositorioTests : IDisposable
{
    private readonly InfinityAppDbContext _contexto;
    private readonly ObraRepositorio _repositorio;

    public ObraRepositorioTests()
    {
        var options = new DbContextOptionsBuilder<InfinityAppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _contexto = new InfinityAppDbContext(options);
        _repositorio = new ObraRepositorio(_contexto);
    }

    [Fact]
    public async Task AdicionarAsync_DeveAdicionarObraAoContexto()
    {
        // Arrange
        var obra = new Obra
        {
            Codigo = "OBR001",
            Nome = "Obra Teste",
            DataInicio = DateTime.Today,
            Ativa = true
        };

        // Act
        await _repositorio.AdicionarAsync(obra);
        await _contexto.SaveChangesAsync();

        // Assert
        var obraRecuperada = await _repositorio.ObterPorIdAsync(obra.Id);
        obraRecuperada.Should().NotBeNull();
        obraRecuperada!.Codigo.Should().Be("OBR001");
        obraRecuperada.Nome.Should().Be("Obra Teste");
    }

    [Fact]
    public async Task ObterPorCodigoAsync_ComCodigoExistente_DeveRetornarObra()
    {
        // Arrange
        var obra = new Obra
        {
            Codigo = "OBR002",
            Nome = "Obra Teste 2",
            DataInicio = DateTime.Today,
            Ativa = true
        };

        await _repositorio.AdicionarAsync(obra);
        await _contexto.SaveChangesAsync();

        // Act
        var obraRecuperada = await _repositorio.ObterPorCodigoAsync("OBR002");

        // Assert
        obraRecuperada.Should().NotBeNull();
        obraRecuperada!.Id.Should().Be(obra.Id);
    }

    [Fact]
    public async Task ObterPorCodigoAsync_ComCodigoInexistente_DeveRetornarNull()
    {
        // Act
        var obraRecuperada = await _repositorio.ObterPorCodigoAsync("OBR999");

        // Assert
        obraRecuperada.Should().BeNull();
    }

    [Fact]
    public async Task ObterObrasAtivasAsync_DeveRetornarApenasObrasAtivas()
    {
        // Arrange
        var obraAtiva1 = new Obra
        {
            Codigo = "OBR003",
            Nome = "Obra Ativa 1",
            DataInicio = DateTime.Today,
            Ativa = true
        };

        var obraAtiva2 = new Obra
        {
            Codigo = "OBR004",
            Nome = "Obra Ativa 2",
            DataInicio = DateTime.Today,
            Ativa = true
        };

        var obraInativa = new Obra
        {
            Codigo = "OBR005",
            Nome = "Obra Inativa",
            DataInicio = DateTime.Today,
            Ativa = false
        };

        await _repositorio.AdicionarAsync(obraAtiva1);
        await _repositorio.AdicionarAsync(obraAtiva2);
        await _repositorio.AdicionarAsync(obraInativa);
        await _contexto.SaveChangesAsync();

        // Act
        var obrasAtivas = await _repositorio.ObterObrasAtivasAsync();

        // Assert
        obrasAtivas.Should().HaveCount(2);
        obrasAtivas.Should().Contain(o => o.Codigo == "OBR003");
        obrasAtivas.Should().Contain(o => o.Codigo == "OBR004");
        obrasAtivas.Should().NotContain(o => o.Codigo == "OBR005");
    }

    [Fact]
    public async Task Atualizar_DeveAtualizarObraNoContexto()
    {
        // Arrange
        var obra = new Obra
        {
            Codigo = "OBR006",
            Nome = "Obra Original",
            DataInicio = DateTime.Today,
            Ativa = true
        };

        await _repositorio.AdicionarAsync(obra);
        await _contexto.SaveChangesAsync();

        // Act
        obra.Nome = "Obra Atualizada";
        _repositorio.Atualizar(obra);
        await _contexto.SaveChangesAsync();

        // Assert
        var obraRecuperada = await _repositorio.ObterPorIdAsync(obra.Id);
        obraRecuperada!.Nome.Should().Be("Obra Atualizada");
    }

    [Fact]
    public async Task Remover_DeveRemoverObraDoContexto()
    {
        // Arrange
        var obra = new Obra
        {
            Codigo = "OBR007",
            Nome = "Obra a Remover",
            DataInicio = DateTime.Today,
            Ativa = true
        };

        await _repositorio.AdicionarAsync(obra);
        await _contexto.SaveChangesAsync();

        // Act
        _repositorio.Remover(obra);
        await _contexto.SaveChangesAsync();

        // Assert
        var obraRecuperada = await _repositorio.ObterPorIdAsync(obra.Id);
        obraRecuperada.Should().BeNull();
    }

    [Fact]
    public async Task ExisteAsync_ComPredicadoVerdadeiro_DeveRetornarTrue()
    {
        // Arrange
        var obra = new Obra
        {
            Codigo = "OBR008",
            Nome = "Obra Existe",
            DataInicio = DateTime.Today,
            Ativa = true
        };

        await _repositorio.AdicionarAsync(obra);
        await _contexto.SaveChangesAsync();

        // Act
        var existe = await _repositorio.ExisteAsync(o => o.Codigo == "OBR008");

        // Assert
        existe.Should().BeTrue();
    }

    [Fact]
    public async Task ExisteAsync_ComPredicadoFalso_DeveRetornarFalse()
    {
        // Act
        var existe = await _repositorio.ExisteAsync(o => o.Codigo == "OBR999");

        // Assert
        existe.Should().BeFalse();
    }

    [Fact]
    public async Task ContarAsync_DeveRetornarQuantidadeCorreta()
    {
        // Arrange
        var obra1 = new Obra { Codigo = "OBR009", Nome = "Obra 1", DataInicio = DateTime.Today, Ativa = true };
        var obra2 = new Obra { Codigo = "OBR010", Nome = "Obra 2", DataInicio = DateTime.Today, Ativa = true };
        var obra3 = new Obra { Codigo = "OBR011", Nome = "Obra 3", DataInicio = DateTime.Today, Ativa = false };

        await _repositorio.AdicionarAsync(obra1);
        await _repositorio.AdicionarAsync(obra2);
        await _repositorio.AdicionarAsync(obra3);
        await _contexto.SaveChangesAsync();

        // Act
        var quantidadeAtivas = await _repositorio.ContarAsync(o => o.Ativa);

        // Assert
        quantidadeAtivas.Should().Be(2);
    }

    public void Dispose()
    {
        _contexto.Dispose();
    }
}
