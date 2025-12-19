using Aplication.Servicos.Autenticacao;
using Aplication.Servicos.Cache;
using Aplication.Servicos.Comum;
using Aplication.Servicos.Fichas;
using Aplication.Servicos.Interfaces;
using Aplication.Servicos.Sincronizacao;
using Apresentacao.Services;
using Domain.Interfaces.Repositorios;
using InfinityApp.Application.Mapeamentos;
using Infrastructure.Configuracoes;
using Infrastructure.Persistencia.Contexto;
using Infrastructure.Persistencia.Repositorios;
using Infrastructure.ServicosExternos.ApiInfinity;
using Infrastructure.ServicosExternos.ApiInfinity.Configuracao;
using Infrastructure.ServicosExternos.Keycloak;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Apresentacao
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // ========================================
            // CONFIGURAÇÃO DO KEYCLOAK
            // ========================================
            var keycloakConfig = new KeycloakConfig
            {
                Authority = "http://10.0.2.2:8080",
                Realm = "infinityapp-teste",
                ClientId = "infinity-app",
                RedirectUri = "infinityapp://oauth2redirect",
                Scopes = "openid profile email offline_access"
            };

            builder.Services.AddSingleton(keycloakConfig);

            // ========================================
            // SERVIÇOS DE AUTENTICAÇÃO
            // ========================================

            // SecureStorage - Implementação MAUI (Android Keystore, iOS Keychain)
            builder.Services.AddSingleton<ISecureStorageService, MauiSecureStorageService>();
            // Navegador - Implementação MAUI (Chrome Custom Tabs, etc)
            builder.Services.AddSingleton<INavegadorAutenticacao, MauiNavegadorAutenticacao>();

            // Cliente HTTP Keycloak
            builder.Services.AddSingleton(sp =>
            {
                var httpClient = new HttpClient();
                return new KeycloakHttpClient(httpClient, keycloakConfig);
            });

            // Serviço de Autenticação
            builder.Services.AddScoped<IAutenticacaoService, ServicoAutenticacao>();

            // ========================================
            // BANCO DE DADOS
            // ========================================
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "infinityapp.db");
            builder.Services.AddDbContext<InfinityAppDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));

            // ========================================
            // REPOSITÓRIOS
            // ========================================
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IObraRepositorio, ObraRepositorio>();
            builder.Services.AddScoped<IServicoRepositorio, ServicoRepositorio>();
            builder.Services.AddScoped<ITrechoRepositorio, TrechoRepositorio>();
            builder.Services.AddScoped<IMaterialRepositorio, MaterialRepositorio>();
            builder.Services.AddScoped<IEquipamentoRepositorio, EquipamentoRepositorio>();
            builder.Services.AddScoped<IDepositoRepositorio, DepositoRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            // Repositórios de Fichas
            builder.Services.AddScoped<FichaLimpezaPistaRepositorio>();
            builder.Services.AddScoped<FichaViagemCBRepositorio>();
            builder.Services.AddScoped<FichaBotaDentroRepositorio>();
            builder.Services.AddScoped<FichaFresagemRepositorio>();
            builder.Services.AddScoped<FichaCBUQRepositorio>();
            builder.Services.AddScoped<FichaMicrorevestimentoRepositorio>();

            // ========================================
            // API INFINITY CLIENT
            // ========================================
            var apiInfinityConfig = new ApiInfinityConfig
            {
                BaseUrl = "https://api.infinity.caiapoconstrucoes.com.br",
                TimeoutSeconds = 30,
                MaxRetryAttempts = 3
            };

            builder.Services.AddSingleton(apiInfinityConfig);
            builder.Services.AddSingleton<IApiInfinityClient>(sp =>
            {
                var httpClient = new HttpClient();
                var autenticacao = sp.GetRequiredService<IAutenticacaoService>();
                return new ApiInfinityClient(
                    httpClient,
                    apiInfinityConfig,
                    autenticacao
                );
            });

            // ========================================
            // SERVIÇOS DE APLICAÇÃO
            // ========================================
            builder.Services.AddSingleton<ServicoCacheMemoria>();
            builder.Services.AddScoped<ServicoSincronizacao>();
            builder.Services.AddScoped<ServicoSincronizacaoPull>();

            // Serviço de Autenticação (Application)
            builder.Services.AddScoped<IServicoAutenticacaoApp, ServicoAutenticacaoApp>();

            // Serviços Comuns
            builder.Services.AddScoped<IServicoObra, ServicoObra>();
            builder.Services.AddScoped<IServicoServico, ServicoServico>();
            builder.Services.AddScoped<IServicoTrecho, ServicoTrecho>();
            builder.Services.AddScoped<IServicoMaterial, ServicoMaterial>();
            builder.Services.AddScoped<IServicoEquipamento, ServicoEquipamento>();
            builder.Services.AddScoped<IServicoDeposito, ServicoDeposito>();

            // Serviços de Fichas
            builder.Services.AddScoped<ServicoFichaLimpezaPista>();
            builder.Services.AddScoped<ServicoFichaViagemCB>();
            builder.Services.AddScoped<ServicoFichaBotaDentro>();
            builder.Services.AddScoped<ServicoFichaFresagem>();
            builder.Services.AddScoped<ServicoFichaCBUQ>();
            builder.Services.AddScoped<ServicoFichaMicrorevestimento>();

            // ========================================
            // AUTOMAPPER
            // ========================================
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            // ========================================
            // LOGGING DO MAUI
            // ========================================

#if DEBUG
            builder.Logging.AddDebug();
            builder.Logging.SetMinimumLevel(LogLevel.Trace);
#else
        builder.Logging.SetMinimumLevel(LogLevel.Warning);
#endif
            return builder.Build();
        }
    }
}
