namespace Aplication.Servicos.Sincronizacao;

/// <summary>
/// Resultado da sincronização pull.
/// </summary>
public class ResultadoSincronizacaoPull
{
    public bool Sucesso { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public string? MensagemErro { get; set; }
    public int QuantidadeObras { get; set; }
    public int QuantidadeServicos { get; set; }
    public int QuantidadeTrechos { get; set; }
    public int QuantidadeMateriais { get; set; }
    public int QuantidadeEquipamentos { get; set; }
    public int QuantidadeDepositos { get; set; }

    public TimeSpan Duracao => (DataFim ?? DateTime.UtcNow) - DataInicio;
    public int TotalItens => QuantidadeObras + QuantidadeServicos + QuantidadeTrechos +
                              QuantidadeMateriais + QuantidadeEquipamentos + QuantidadeDepositos;
}
