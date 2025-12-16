using Domain.ObjetosDeValor;
using FluentAssertions;

namespace Domain.Test.ObjetosDeValor;

/// <summary>
/// Testes unitários para o Value Object Periodo.
/// </summary>
public class PeriodoTests
{
    [Fact]
    public void Criar_ComHorasValidas_DeveCriarPeriodo()
    {
        // Arrange
        var horaInicio = new TimeSpan(8, 0, 0);   // 08:00
        var horaFim = new TimeSpan(17, 0, 0);     // 17:00

        // Act
        var periodo = Periodo.Criar(horaInicio, horaFim);

        // Assert
        periodo.Should().NotBeNull();
        periodo.HoraInicio.Should().Be(horaInicio);
        periodo.HoraFim.Should().Be(horaFim);
    }

    [Fact]
    public void Criar_ComHoraInicioMaiorQueFim_DeveLancarExcecao()
    {
        // Arrange
        var horaInicio = new TimeSpan(17, 0, 0);  // 17:00
        var horaFim = new TimeSpan(8, 0, 0);      // 08:00

        // Act
        Action acao = () => Periodo.Criar(horaInicio, horaFim);

        // Assert
        acao.Should().Throw<ArgumentException>()
            .WithMessage("*hora de início deve ser anterior à hora de fim*");
    }

    [Fact]
    public void ObterDuracaoEmMinutos_DeveCalcularCorretamente()
    {
        // Arrange
        var horaInicio = new TimeSpan(8, 0, 0);   // 08:00
        var horaFim = new TimeSpan(17, 30, 0);    // 17:30
        var periodo = Periodo.Criar(horaInicio, horaFim);

        // Act
        var duracao = periodo.ObterDuracaoEmMinutos();

        // Assert
        duracao.Should().Be(570); // 9 horas e 30 minutos = 570 minutos
    }

    [Fact]
    public void ObterDuracaoEmMinutos_ComPeriodoCurto_DeveCalcularCorretamente()
    {
        // Arrange
        var horaInicio = new TimeSpan(14, 15, 0);  // 14:15
        var horaFim = new TimeSpan(14, 45, 0);     // 14:45
        var periodo = Periodo.Criar(horaInicio, horaFim);

        // Act
        var duracao = periodo.ObterDuracaoEmMinutos();

        // Assert
        duracao.Should().Be(30); // 30 minutos
    }

    [Fact]
    public void Equals_ComPeriodosIguais_DeveRetornarTrue()
    {
        // Arrange
        var periodo1 = Periodo.Criar(new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0));
        var periodo2 = Periodo.Criar(new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0));

        // Act & Assert
        periodo1.Should().Be(periodo2);
        (periodo1 == periodo2).Should().BeTrue();
    }

    [Fact]
    public void Equals_ComPeriodosDiferentes_DeveRetornarFalse()
    {
        // Arrange
        var periodo1 = Periodo.Criar(new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0));
        var periodo2 = Periodo.Criar(new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0));

        // Act & Assert
        periodo1.Should().NotBe(periodo2);
        (periodo1 != periodo2).Should().BeTrue();
    }

    [Theory]
    [InlineData(0, 0, 23, 59)]    // Dia completo
    [InlineData(6, 0, 14, 0)]     // Período manhã
    [InlineData(14, 0, 22, 0)]    // Período tarde/noite
    [InlineData(8, 30, 12, 15)]   // Período com minutos
    public void Criar_ComDiferentesPeriodos_DeveCriarPeriodo(int horaInicio, int minutoInicio, int horaFim, int minutoFim)
    {
        // Arrange
        var inicio = new TimeSpan(horaInicio, minutoInicio, 0);
        var fim = new TimeSpan(horaFim, minutoFim, 0);

        // Act
        var periodo = Periodo.Criar(inicio, fim);

        // Assert
        periodo.Should().NotBeNull();
        periodo.HoraInicio.Should().Be(inicio);
        periodo.HoraFim.Should().Be(fim);
    }

    [Fact]
    public void ToString_DeveFormatarCorretamente()
    {
        // Arrange
        var periodo = Periodo.Criar(new TimeSpan(8, 30, 0), new TimeSpan(17, 45, 0));

        // Act
        var texto = periodo.ToString();

        // Assert
        texto.Should().Be("08:30:00 - 17:45:00");
    }
}
