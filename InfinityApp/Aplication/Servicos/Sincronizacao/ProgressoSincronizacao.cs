namespace Aplication.Servicos.Sincronizacao;

/// <summary>
/// Progresso da sincronização.
/// </summary>
public class ProgressoSincronizacao
{
    public string Mensagem { get; set; } = string.Empty;
    public int ItemAtual { get; set; }
    public int TotalItens { get; set; }
    public int Porcentagem { get; set; }
}
