namespace Domain.Enums;

/// <summary>
/// Níveis de log do aplicativo.
/// Ordenados do menos para o mais severo.
/// </summary>
public enum NivelLog
{
    /// <summary>
    /// Informações extremamente detalhadas, geralmente apenas em debug avançado.
    /// </summary>
    Trace = 0,

    /// <summary>
    /// Informações úteis para debug durante desenvolvimento.
    /// </summary>
    Debug = 1,

    /// <summary>
    /// Informações gerais sobre o fluxo do aplicativo.
    /// </summary>
    Information = 2,

    /// <summary>
    /// Avisos sobre situações anormais mas que não impedem execução.
    /// </summary>
    Warning = 3,

    /// <summary>
    /// Erros que precisam de atenção mas não são críticos.
    /// </summary>
    Error = 4,

    /// <summary>
    /// Erros críticos que podem interromper o aplicativo.
    /// </summary>
    Fatal = 5
}