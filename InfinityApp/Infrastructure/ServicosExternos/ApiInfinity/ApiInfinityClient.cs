using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Aplication.ApiInfinityResponse.Modelos;
using Aplication.Servicos.Interfaces;
using Infrastructure.ServicosExternos.ApiInfinity.Configuracao;

namespace Infrastructure.ServicosExternos.ApiInfinity;

/// <summary>
/// Cliente HTTP para comunicação com a API Infinity.
/// </summary>
public class ApiInfinityClient : IApiInfinityClient
{
    private readonly HttpClient _httpClient;
    private readonly ApiInfinityConfig _config;
    private readonly IAutenticacaoService _autenticacaoService;
    private readonly JsonSerializerOptions _jsonOptions;

    public ApiInfinityClient(HttpClient httpClient, ApiInfinityConfig config, IAutenticacaoService autenticacaoService)
    {
        _httpClient = httpClient;
        _config = config;
        _autenticacaoService = autenticacaoService;

        _httpClient.BaseAddress = new Uri(_config.BaseUrl);
        _httpClient.Timeout = TimeSpan.FromSeconds(_config.TimeoutSeconds);

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    /// <summary>
    /// Obtém todas as obras do usuário autenticado.
    /// </summary>
    public async Task<List<ObraResponse>> ObterObrasAsync(CancellationToken cancellationToken = default)
    {
        await ConfigurarAutenticacaoAsync();

        var response = await _httpClient.GetAsync(_config.ObrasEndpoint, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<ObraResponse>>(_jsonOptions, cancellationToken) ?? [];
    }

    /// <summary>
    /// Obtém todos os serviços de uma obra.
    /// </summary>
    public async Task<List<ServicoResponse>> ObterServicosAsync(string codigoObra, CancellationToken cancellationToken = default)
    {
        await ConfigurarAutenticacaoAsync();

        var url = $"{_config.ServicosEndpoint}?codigoObra={Uri.EscapeDataString(codigoObra)}";
        var response = await _httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<ServicoResponse>>(_jsonOptions, cancellationToken) ?? [];
    }

    /// <summary>
    /// Obtém todos os trechos de uma obra.
    /// </summary>
    public async Task<List<TrechoResponse>> ObterTrechosAsync(string codigoObra, CancellationToken cancellationToken = default)
    {
        await ConfigurarAutenticacaoAsync();

        var url = $"{_config.TrechosEndpoint}?codigoObra={Uri.EscapeDataString(codigoObra)}";
        var response = await _httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<TrechoResponse>>(_jsonOptions, cancellationToken) ?? [];
    }

    /// <summary>
    /// Obtém todos os materiais.
    /// </summary>
    public async Task<List<MaterialResponse>> ObterMateriaisAsync(CancellationToken cancellationToken = default)
    {
        await ConfigurarAutenticacaoAsync();

        var response = await _httpClient.GetAsync(_config.MateriaisEndpoint, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<MaterialResponse>>(_jsonOptions, cancellationToken) ?? [];
    }

    /// <summary>
    /// Obtém todos os equipamentos.
    /// </summary>
    public async Task<List<EquipamentoResponse>> ObterEquipamentosAsync(CancellationToken cancellationToken = default)
    {
        await ConfigurarAutenticacaoAsync();

        var response = await _httpClient.GetAsync(_config.EquipamentosEndpoint, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<EquipamentoResponse>>(_jsonOptions, cancellationToken) ?? [];
    }

    /// <summary>
    /// Obtém todos os depósitos ativos.
    /// </summary>
    public async Task<List<DepositoResponse>> ObterDepositosAsync(CancellationToken cancellationToken = default)
    {
        await ConfigurarAutenticacaoAsync();

        var response = await _httpClient.GetAsync(_config.DepositosEndpoint, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<DepositoResponse>>(_jsonOptions, cancellationToken) ?? [];
    }

    /// <summary>
    /// Sincroniza fichas de produção para a API.
    /// </summary>
    public async Task<bool> SincronizarFichasAsync<T>(string categoria, T dados, CancellationToken cancellationToken = default)
    {
        await ConfigurarAutenticacaoAsync();

        var url = _config.SincronizacaoEndpoint(categoria);
        var response = await _httpClient.PostAsJsonAsync(url, dados, _jsonOptions, cancellationToken);

        return response.IsSuccessStatusCode;
    }

    /// <summary>
    /// Configura o header de autenticação com o bearer token.
    /// </summary>
    private async Task ConfigurarAutenticacaoAsync()
    {
        var token = await _autenticacaoService.ObterAccessTokenAsync();

        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
