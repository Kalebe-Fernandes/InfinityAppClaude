namespace Domain.ObjetosDeValor;

/// <summary>
/// Representa uma estaca com sua fração, utilizada para localização em rodovias.
/// Value Object imutável que garante a validade dos dados.
/// </summary>
public class Estaca
{
    /// <summary>
    /// Número inteiro da estaca (ex: 10 para estaca 10+5.50).
    /// </summary>
    public int Numero { get; }

    /// <summary>
    /// Fração da estaca, valor entre 0.00 e 19.99 metros.
    /// </summary>
    public decimal Fracao { get; }

    /// <summary>
    /// Construtor privado para garantir validação.
    /// </summary>
    private Estaca(int numero, decimal fracao)
    {
        Numero = numero;
        Fracao = fracao;
    }

    /// <summary>
    /// Cria uma nova instância de Estaca validando os parâmetros.
    /// </summary>
    /// <param name="numero">Número da estaca (deve ser >= 0).</param>
    /// <param name="fracao">Fração da estaca (deve estar entre 0.00 e 19.99).</param>
    /// <returns>Instância válida de Estaca.</returns>
    /// <exception cref="ArgumentException">Lançada quando os parâmetros são inválidos.</exception>
    public static Estaca Criar(int numero, decimal fracao)
    {
        if (numero < 0)
            throw new ArgumentException("O número da estaca deve ser maior ou igual a zero.", nameof(numero));

        if (fracao < 0 || fracao >= 20)
            throw new ArgumentException("A fração da estaca deve estar entre 0.00 e 19.99.", nameof(fracao));

        return new Estaca(numero, fracao);
    }

    /// <summary>
    /// Converte a estaca para metros.
    /// Cada estaca equivale a 20 metros, mais a fração.
    /// </summary>
    /// <returns>Valor total em metros.</returns>
    public decimal ParaMetros()
    {
        return Numero * 20 + Fracao;
    }

    /// <summary>
    /// Retorna a representação textual da estaca no formato "Numero+Fracao".
    /// </summary>
    public override string ToString()
    {
        return $"{Numero}+{Fracao:F2}";
    }

    /// <summary>
    /// Compara duas estacas verificando se possuem os mesmos valores.
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is not Estaca outraEstaca)
            return false;

        return Numero == outraEstaca.Numero && Fracao == outraEstaca.Fracao;
    }

    /// <summary>
    /// Retorna o código hash baseado nos valores da estaca.
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(Numero, Fracao);
    }

    /// <summary>
    /// Operador de igualdade.
    /// </summary>
    public static bool operator ==(Estaca? a, Estaca? b)
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
    public static bool operator !=(Estaca? a, Estaca? b)
    {
        return !(a == b);
    }

    /// <summary>
    /// Operador de comparação maior que.
    /// </summary>
    public static bool operator >(Estaca a, Estaca b)
    {
        return a.ParaMetros() > b.ParaMetros();
    }

    /// <summary>
    /// Operador de comparação menor que.
    /// </summary>
    public static bool operator <(Estaca a, Estaca b)
    {
        return a.ParaMetros() < b.ParaMetros();
    }

    /// <summary>
    /// Operador de comparação maior ou igual.
    /// </summary>
    public static bool operator >=(Estaca a, Estaca b)
    {
        return a.ParaMetros() >= b.ParaMetros();
    }

    /// <summary>
    /// Operador de comparação menor ou igual.
    /// </summary>
    public static bool operator <=(Estaca a, Estaca b)
    {
        return a.ParaMetros() <= b.ParaMetros();
    }
}
