namespace Domain.ObjetosDeValor;

/// <summary>
/// Representa um período de tempo com hora de início e fim.
/// Value Object imutável utilizado para registrar horários de carregamento e descarregamento.
/// </summary>
public class Periodo
{
    /// <summary>
    /// Hora de início do período.
    /// </summary>
    public TimeSpan HoraInicio { get; }

    /// <summary>
    /// Hora de fim do período.
    /// </summary>
    public TimeSpan HoraFim { get; }

    /// <summary>
    /// Construtor privado para garantir validação.
    /// </summary>
    private Periodo(TimeSpan horaInicio, TimeSpan horaFim)
    {
        HoraInicio = horaInicio;
        HoraFim = horaFim;
    }

    /// <summary>
    /// Cria uma nova instância de Periodo validando os parâmetros.
    /// </summary>
    /// <param name="horaInicio">Hora de início.</param>
    /// <param name="horaFim">Hora de fim.</param>
    /// <returns>Instância válida de Periodo.</returns>
    /// <exception cref="ArgumentException">Lançada quando a hora de início é maior que a de fim.</exception>
    public static Periodo Criar(TimeSpan horaInicio, TimeSpan horaFim)
    {
        if (horaInicio > horaFim)
            throw new ArgumentException("A hora de início não pode ser maior que a hora de fim.");

        return new Periodo(horaInicio, horaFim);
    }

    /// <summary>
    /// Calcula a duração do período em minutos.
    /// </summary>
    /// <returns>Duração em minutos.</returns>
    public double ObterDuracaoEmMinutos()
    {
        return (HoraFim - HoraInicio).TotalMinutes;
    }

    /// <summary>
    /// Retorna a representação textual do período.
    /// </summary>
    public override string ToString()
    {
        return $"{HoraInicio:hh\\:mm} às {HoraFim:hh\\:mm}";
    }

    /// <summary>
    /// Compara dois períodos verificando se possuem os mesmos valores.
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is not Periodo outroPeriodo)
            return false;

        return HoraInicio == outroPeriodo.HoraInicio && HoraFim == outroPeriodo.HoraFim;
    }

    /// <summary>
    /// Retorna o código hash baseado nos valores do período.
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(HoraInicio, HoraFim);
    }

    /// <summary>
    /// Operador de igualdade.
    /// </summary>
    public static bool operator ==(Periodo? a, Periodo? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    /// <summary>
    /// Operador de desigualdade.
    /// </summary>
    public static bool operator !=(Periodo? a, Periodo? b)
    {
        return !(a == b);
    }
}
