namespace Domain.Enums;

/// <summary>
/// Representa o lado da pista onde o serviço foi executado.
/// </summary>
public enum Lado
{
    /// <summary>
    /// Lado Direito da pista.
    /// </summary>
    LD = 0,

    /// <summary>
    /// Lado Esquerdo da pista.
    /// </summary>
    LE = 1,

    /// <summary>
    /// Ambos os lados (Lado Direito e Lado Esquerdo).
    /// </summary>
    LD_LE = 2,

    /// <summary>
    /// Canteiro Central.
    /// </summary>
    CC = 3
}
