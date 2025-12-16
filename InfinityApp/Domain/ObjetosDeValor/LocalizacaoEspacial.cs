using Domain.Enums;

namespace Domain.ObjetosDeValor;

/// <summary>
/// Representa uma localização espacial completa em uma rodovia,
/// incluindo estacas inicial e final e o lado da pista.
/// Value Object imutável que garante a consistência das localizações.
/// </summary>
public class LocalizacaoEspacial
{
    /// <summary>
    /// Estaca inicial da localização.
    /// </summary>
    public Estaca EstacaInicial { get; }

    /// <summary>
    /// Estaca final da localização.
    /// </summary>
    public Estaca EstacaFinal { get; }

    /// <summary>
    /// Lado da pista onde o serviço foi executado.
    /// </summary>
    public Lado Lado { get; }

    /// <summary>
    /// Construtor privado para garantir validação.
    /// </summary>
    private LocalizacaoEspacial(Estaca estacaInicial, Estaca estacaFinal, Lado lado)
    {
        EstacaInicial = estacaInicial;
        EstacaFinal = estacaFinal;
        Lado = lado;
    }

    /// <summary>
    /// Cria uma nova instância de LocalizacaoEspacial validando os parâmetros.
    /// </summary>
    /// <param name="estacaInicial">Estaca inicial.</param>
    /// <param name="estacaFinal">Estaca final.</param>
    /// <param name="lado">Lado da pista.</param>
    /// <returns>Instância válida de LocalizacaoEspacial.</returns>
    /// <exception cref="ArgumentException">Lançada quando a estaca inicial é maior que a final.</exception>
    public static LocalizacaoEspacial Criar(Estaca estacaInicial, Estaca estacaFinal, Lado lado)
    {
        if (estacaInicial > estacaFinal)
            throw new ArgumentException("A estaca inicial não pode ser maior que a estaca final.");

        return new LocalizacaoEspacial(estacaInicial, estacaFinal, lado);
    }

    /// <summary>
    /// Calcula a extensão em metros entre as estacas inicial e final.
    /// </summary>
    /// <returns>Extensão em metros.</returns>
    public decimal ObterExtensao()
    {
        return EstacaFinal.ParaMetros() - EstacaInicial.ParaMetros();
    }

    /// <summary>
    /// Retorna a representação textual da localização espacial.
    /// </summary>
    public override string ToString()
    {
        return $"{EstacaInicial} a {EstacaFinal} - Lado: {Lado}";
    }

    /// <summary>
    /// Compara duas localizações espaciais verificando se possuem os mesmos valores.
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is not LocalizacaoEspacial outraLocalizacao)
            return false;

        return EstacaInicial == outraLocalizacao.EstacaInicial &&
               EstacaFinal == outraLocalizacao.EstacaFinal &&
               Lado == outraLocalizacao.Lado;
    }

    /// <summary>
    /// Retorna o código hash baseado nos valores da localização espacial.
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(EstacaInicial, EstacaFinal, Lado);
    }

    /// <summary>
    /// Operador de igualdade.
    /// </summary>
    public static bool operator ==(LocalizacaoEspacial? a, LocalizacaoEspacial? b)
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
    public static bool operator !=(LocalizacaoEspacial? a, LocalizacaoEspacial? b)
    {
        return !(a == b);
    }
}
