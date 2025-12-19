using Domain.Enums;

namespace Domain.Entidades.Logging;

/// <summary>
/// Estatísticas agregadas de logs.
/// </summary>
public class EstatisticasLog
{
    public int TotalLogs { get; set; }
    public int TotalTrace { get; set; }
    public int TotalDebug { get; set; }
    public int TotalInformation { get; set; }
    public int TotalWarning { get; set; }
    public int TotalError { get; set; }
    public int TotalFatal { get; set; }
    
    public Dictionary<CategoriaLog, int> PorCategoria { get; set; } = new();
    public DateTime? PrimeiroLog { get; set; }
    public DateTime? UltimoLog { get; set; }
}
