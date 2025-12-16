namespace Domain.Enums;

/// <summary>
/// Representa o tipo de referência de localização utilizado no trecho.
/// </summary>
public enum TipoReferencia
{
    /// <summary>
    /// Referência por Estaca (ex: 0+10.50).
    /// </summary>
    Estaca = 0,

    /// <summary>
    /// Referência por Quilômetro (ex: KM 25).
    /// </summary>
    Quilometro = 1
}
