using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Infrastructure.ServicosExternos.Keycloak;
using Apresentacao.Services;
using Infrastructure.Persistencia.Contexto;
using Infrastructure.Configuracoes;
using Domain.Interfaces.Repositorios;
using Infrastructure.Persistencia.Repositorios;
using Aplication.Servicos.Cache;
using Aplication.Servicos.Sincronizacao;
using Aplication.Servicos.Fichas;
using InfinityApp.Application.Mapeamentos;
using Aplication.Servicos.Interfaces;

namespace Apresentacao;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Configurar Blazor
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
            Authority = "https://auth.caiapoconstrucoes.com.br",
            Realm = "infinity-realm",
            ClientId = "infinity-app",
            RedirectUri = "infinityapp://callback",
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
        // SERVIÇOS DE APLICAÇÃO
        // ========================================
        builder.Services.AddSingleton<ServicoCacheMemoria, ServicoCacheMemoria>();
        builder.Services.AddScoped<ServicoSincronizacao, ServicoSincronizacao>();

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

        return builder.Build();
    }
}
