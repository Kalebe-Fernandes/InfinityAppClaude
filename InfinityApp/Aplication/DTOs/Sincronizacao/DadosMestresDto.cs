namespace Aplication.DTOs.Sincronizacao;

/// <summary>
/// DTO para dados mestres baixados na sincronização Pull.
/// </summary>
public class DadosMestresDto
{
    /// <summary>
    /// Lista de obras do usuário.
    /// </summary>
    public List<ObraDto> Obras { get; set; } = [];

    /// <summary>
    /// Lista de serviços.
    /// </summary>
    public List<ServicoDto> Servicos { get; set; } = [];

    /// <summary>
    /// Lista de trechos.
    /// </summary>
    public List<TrechoDto> Trechos { get; set; } = [];

    /// <summary>
    /// Lista de materiais.
    /// </summary>
    public List<MaterialDto> Materiais { get; set; } = [];

    /// <summary>
    /// Lista de equipamentos.
    /// </summary>
    public List<EquipamentoDto> Equipamentos { get; set; } = [];

    /// <summary>
    /// Lista de depósitos.
    /// </summary>
    public List<DepositoDto> Depositos { get; set; } = [];

    /// <summary>
    /// Data e hora da sincronização.
    /// </summary>
    public DateTime DataSincronizacao { get; set; } = DateTime.UtcNow;
}
