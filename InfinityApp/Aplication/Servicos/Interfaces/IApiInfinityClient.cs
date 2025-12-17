using Aplication.ApiInfinityResponse.Modelos;

namespace Aplication.Servicos.Interfaces;

/// <summary>
/// Interface para cliente HTTP da API Infinity.
/// </summary>
public interface IApiInfinityClient
{
    /// <summary>
    /// Obtém todas as obras do usuário autenticado.
    /// </summary>
    Task<List<ObraResponse>> ObterObrasAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtém todos os serviços de uma obra.
    /// </summary>
    Task<List<ServicoResponse>> ObterServicosAsync(string codigoObra, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtém todos os trechos de uma obra.
    /// </summary>
    Task<List<TrechoResponse>> ObterTrechosAsync(string codigoObra, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtém todos os materiais.
    /// </summary>
    Task<List<MaterialResponse>> ObterMateriaisAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtém todos os equipamentos.
    /// </summary>
    Task<List<EquipamentoResponse>> ObterEquipamentosAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtém todos os depósitos ativos.
    /// </summary>
    Task<List<DepositoResponse>> ObterDepositosAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Sincroniza fichas de produção para a API.
    /// </summary>
    Task<bool> SincronizarFichasAsync<T>(string categoria, T dados, CancellationToken cancellationToken = default);
}
