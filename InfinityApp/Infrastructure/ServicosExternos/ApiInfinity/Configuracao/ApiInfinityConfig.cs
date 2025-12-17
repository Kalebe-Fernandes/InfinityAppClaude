namespace Infrastructure.ServicosExternos.ApiInfinity.Configuracao;

/// <summary>
/// Configurações da API Infinity.
/// </summary>
public class ApiInfinityConfig
{
    /// <summary>
    /// URL base da API Infinity.
    /// Exemplo: https://api.infinity.caiapoconstrucoes.com.br
    /// </summary>
    public string BaseUrl { get; set; } = string.Empty;

    /// <summary>
    /// Timeout em segundos para requisições (padrão: 30 segundos).
    /// </summary>
    public int TimeoutSeconds { get; set; } = 30;

    /// <summary>
    /// Número máximo de tentativas em caso de falha (padrão: 3).
    /// </summary>
    public int MaxRetryAttempts { get; set; } = 3;

    /// <summary>
    /// Versão da API (padrão: v1).
    /// </summary>
    public string ApiVersion { get; set; } = "v1";

    /// <summary>
    /// URL completa do endpoint de obras.
    /// </summary>
    public string ObrasEndpoint => $"{BaseUrl}/api/obra";

    /// <summary>
    /// URL completa do endpoint de serviços.
    /// </summary>
    public string ServicosEndpoint => $"{BaseUrl}/api/servico";

    /// <summary>
    /// URL completa do endpoint de trechos.
    /// </summary>
    public string TrechosEndpoint => $"{BaseUrl}/api/trecho/listarparaselecao";

    /// <summary>
    /// URL completa do endpoint de materiais.
    /// </summary>
    public string MateriaisEndpoint => $"{BaseUrl}/api/materiais";

    /// <summary>
    /// URL completa do endpoint de equipamentos.
    /// </summary>
    public string EquipamentosEndpoint => $"{BaseUrl}/api/equipamento";

    /// <summary>
    /// URL completa do endpoint de depósitos.
    /// </summary>
    public string DepositosEndpoint => $"{BaseUrl}/api/deposito/ativos";

    /// <summary>
    /// URL completa do endpoint de sincronização (POST).
    /// </summary>
    public string SincronizacaoEndpoint(string categoria) => $"{BaseUrl}/api/lancamentos-producao-categoria-{categoria}";
}
