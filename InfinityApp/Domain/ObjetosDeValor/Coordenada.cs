namespace Domain.ObjetosDeValor;

/// <summary>
/// Representa uma coordenada geográfica (latitude e longitude).
/// Value Object imutável utilizado para localização de depósitos.
/// </summary>
public class Coordenada
{
    /// <summary>
    /// Latitude em graus decimais (entre -90 e 90).
    /// </summary>
    public decimal Latitude { get; }

    /// <summary>
    /// Longitude em graus decimais (entre -180 e 180).
    /// </summary>
    public decimal Longitude { get; }

    /// <summary>
    /// Construtor privado para garantir validação.
    /// </summary>
    private Coordenada(decimal latitude, decimal longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    /// <summary>
    /// Cria uma nova instância de Coordenada validando os parâmetros.
    /// </summary>
    /// <param name="latitude">Latitude em graus decimais (-90 a 90).</param>
    /// <param name="longitude">Longitude em graus decimais (-180 a 180).</param>
    /// <returns>Instância válida de Coordenada.</returns>
    /// <exception cref="ArgumentException">Lançada quando os parâmetros são inválidos.</exception>
    public static Coordenada Criar(decimal latitude, decimal longitude)
    {
        if (latitude < -90 || latitude > 90)
            throw new ArgumentException("A latitude deve estar entre -90 e 90 graus.", nameof(latitude));

        if (longitude < -180 || longitude > 180)
            throw new ArgumentException("A longitude deve estar entre -180 e 180 graus.", nameof(longitude));

        return new Coordenada(latitude, longitude);
    }

    /// <summary>
    /// Retorna a representação textual da coordenada.
    /// </summary>
    public override string ToString()
    {
        return $"{Latitude:F6}, {Longitude:F6}";
    }

    /// <summary>
    /// Compara duas coordenadas verificando se possuem os mesmos valores.
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is not Coordenada outraCoordenada)
            return false;

        return Latitude == outraCoordenada.Latitude && Longitude == outraCoordenada.Longitude;
    }

    /// <summary>
    /// Retorna o código hash baseado nos valores da coordenada.
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(Latitude, Longitude);
    }

    /// <summary>
    /// Operador de igualdade.
    /// </summary>
    public static bool operator ==(Coordenada? a, Coordenada? b)
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
    public static bool operator !=(Coordenada? a, Coordenada? b)
    {
        return !(a == b);
    }
}
