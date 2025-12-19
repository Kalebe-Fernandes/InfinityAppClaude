using Domain.Entidades.Logging;
using Domain.Enums;
using Domain.Interfaces.Servicos;
using Infrastructure.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Infrastructure.ServicosExternos.Logging;

/// <summary>
/// Implementação do serviço de logging com persistência em SQLite.
/// </summary>
public class ServicoLog : IServicoLog
{
    private readonly InfinityAppDbContext _context;
    private readonly JsonSerializerOptions _jsonOptions;
    private string? _usuarioIdAtual;
    private string? _telaAtual;

    public ServicoLog(InfinityAppDbContext context)
    {
        _context = context;
        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = false,
            PropertyNameCaseInsensitive = true
        };
    }

    /// <summary>
    /// Define o contexto do usuário atual para logs.
    /// </summary>
    public void DefinirContextoUsuario(string usuarioId, string? tela = null)
    {
        _usuarioIdAtual = usuarioId;
        _telaAtual = tela;
    }

    public async Task RegistrarTraceAsync(string origem, string mensagem, CategoriaLog categoria, object? contexto = null)
    {
        await RegistrarAsync(NivelLog.Trace, origem, mensagem, categoria, null, contexto);
    }

    public async Task RegistrarDebugAsync(string origem, string mensagem, CategoriaLog categoria, object? contexto = null)
    {
        await RegistrarAsync(NivelLog.Debug, origem, mensagem, categoria, null, contexto);
    }

    public async Task RegistrarInformacaoAsync(string origem, string mensagem, CategoriaLog categoria, object? contexto = null)
    {
        await RegistrarAsync(NivelLog.Information, origem, mensagem, categoria, null, contexto);
    }

    public async Task RegistrarAvisoAsync(string origem, string mensagem, CategoriaLog categoria, object? contexto = null)
    {
        await RegistrarAsync(NivelLog.Warning, origem, mensagem, categoria, null, contexto);
    }

    public async Task RegistrarErroAsync(string origem, string mensagem, Exception excecao, CategoriaLog categoria, object? contexto = null)
    {
        await RegistrarAsync(NivelLog.Error, origem, mensagem, categoria, excecao, contexto);
    }

    public async Task RegistrarFatalAsync(string origem, string mensagem, Exception excecao, CategoriaLog categoria, object? contexto = null)
    {
        await RegistrarAsync(NivelLog.Fatal, origem, mensagem, categoria, excecao, contexto);
    }

    public async Task<IEnumerable<EntradaLog>> ObterLogsAsync(DateTime dataInicio, DateTime? dataFim = null)
    {
        var query = _context.Logs.Where(l => l.Timestamp >= dataInicio);

        if (dataFim.HasValue)
        {
            query = query.Where(l => l.Timestamp <= dataFim.Value);
        }

        return await query.OrderByDescending(l => l.Timestamp).ToListAsync();
    }

    public async Task<IEnumerable<EntradaLog>> ObterLogsPorNivelAsync(NivelLog nivel)
    {
        return await _context.Logs
            .Where(l => l.Nivel == nivel)
            .OrderByDescending(l => l.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<EntradaLog>> ObterLogsPorCategoriaAsync(CategoriaLog categoria)
    {
        return await _context.Logs
            .Where(l => l.Categoria == categoria)
            .OrderByDescending(l => l.Timestamp)
            .ToListAsync();
    }

    public async Task LimparLogsAntigosAsync(DateTime dataLimite)
    {
        var logsAntigos = await _context.Logs
            .Where(l => l.Timestamp < dataLimite)
            .ToListAsync();

        if (logsAntigos.Any())
        {
            _context.Logs.RemoveRange(logsAntigos);
            await _context.SaveChangesAsync();

            await RegistrarInformacaoAsync(
                "ServicoLog.LimparLogsAntigosAsync",
                $"Removidos {logsAntigos.Count} logs antigos",
                CategoriaLog.Geral
            );
        }
    }

    public async Task<string> ExportarLogsAsync(DateTime dataInicio, DateTime? dataFim = null)
    {
        var logs = await ObterLogsAsync(dataInicio, dataFim);
        var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        var nomeArquivo = $"logs_export_{timestamp}.txt";
        var caminhoCompleto = Path.Combine(Microsoft.Maui.Storage.FileSystem.AppDataDirectory, nomeArquivo);

        using (var writer = new StreamWriter(caminhoCompleto))
        {
            await writer.WriteLineAsync("========================================");
            await writer.WriteLineAsync("INFINITY APP - EXPORTAÇÃO DE LOGS");
            await writer.WriteLineAsync($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            await writer.WriteLineAsync($"Período: {dataInicio:dd/MM/yyyy} até {dataFim?.ToString("dd/MM/yyyy") ?? "Presente"}");
            await writer.WriteLineAsync($"Total de logs: {logs.Count()}");
            await writer.WriteLineAsync("========================================\n");

            foreach (var log in logs)
            {
                await writer.WriteLineAsync($"[{log.Timestamp:dd/MM/yyyy HH:mm:ss}] [{log.Nivel}] [{log.Categoria}]");
                await writer.WriteLineAsync($"Origem: {log.Origem}");
                await writer.WriteLineAsync($"Mensagem: {log.Mensagem}");
                
                if (!string.IsNullOrEmpty(log.UsuarioId))
                    await writer.WriteLineAsync($"Usuário: {log.UsuarioId}");
                
                if (!string.IsNullOrEmpty(log.Tela))
                    await writer.WriteLineAsync($"Tela: {log.Tela}");
                
                if (!string.IsNullOrEmpty(log.ContextoJson))
                    await writer.WriteLineAsync($"Contexto: {log.ContextoJson}");
                
                if (!string.IsNullOrEmpty(log.Excecao))
                {
                    await writer.WriteLineAsync("Exceção:");
                    await writer.WriteLineAsync(log.Excecao);
                }
                
                await writer.WriteLineAsync("----------------------------------------\n");
            }
        }

        return caminhoCompleto;
    }

    public async Task<EstatisticasLog> ObterEstatisticasAsync(DateTime dataInicio, DateTime? dataFim = null)
    {
        var logs = await ObterLogsAsync(dataInicio, dataFim);
        var listaLogs = logs.ToList();

        var estatisticas = new EstatisticasLog
        {
            TotalLogs = listaLogs.Count,
            TotalTrace = listaLogs.Count(l => l.Nivel == NivelLog.Trace),
            TotalDebug = listaLogs.Count(l => l.Nivel == NivelLog.Debug),
            TotalInformation = listaLogs.Count(l => l.Nivel == NivelLog.Information),
            TotalWarning = listaLogs.Count(l => l.Nivel == NivelLog.Warning),
            TotalError = listaLogs.Count(l => l.Nivel == NivelLog.Error),
            TotalFatal = listaLogs.Count(l => l.Nivel == NivelLog.Fatal),
            PrimeiroLog = listaLogs.Any() ? listaLogs.Min(l => l.Timestamp) : null,
            UltimoLog = listaLogs.Any() ? listaLogs.Max(l => l.Timestamp) : null,
            PorCategoria = listaLogs
                .GroupBy(l => l.Categoria)
                .ToDictionary(g => g.Key, g => g.Count())
        };

        return estatisticas;
    }

    private async Task RegistrarAsync(
        NivelLog nivel,
        string origem,
        string mensagem,
        CategoriaLog categoria,
        Exception? excecao,
        object? contexto)
    {
        try
        {
            var entrada = new EntradaLog
            {
                Nivel = nivel,
                Origem = origem,
                Mensagem = mensagem,
                Categoria = categoria,
                UsuarioId = _usuarioIdAtual,
                Tela = _telaAtual
            };

            if (excecao != null)
            {
                entrada.Excecao = FormatarExcecao(excecao);
            }

            if (contexto != null)
            {
                entrada.ContextoJson = JsonSerializer.Serialize(contexto, _jsonOptions);
            }

            _context.Logs.Add(entrada);
            await _context.SaveChangesAsync();

            // Log também no console em debug
            #if DEBUG
            System.Diagnostics.Debug.WriteLine($"[{nivel}] [{categoria}] {origem}: {mensagem}");
            if (excecao != null)
            {
                System.Diagnostics.Debug.WriteLine($"Exceção: {excecao.Message}");
            }
            #endif
        }
        catch (Exception ex)
        {
            // Se falhar ao salvar log, pelo menos escreve no console
            System.Diagnostics.Debug.WriteLine($"ERRO AO SALVAR LOG: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"Log original: [{nivel}] {origem}: {mensagem}");
        }
    }

    private string FormatarExcecao(Exception excecao)
    {
        var detalhes = new System.Text.StringBuilder();
        detalhes.AppendLine($"Tipo: {excecao.GetType().Name}");
        detalhes.AppendLine($"Mensagem: {excecao.Message}");
        detalhes.AppendLine($"Stack Trace:");
        detalhes.AppendLine(excecao.StackTrace);

        if (excecao.InnerException != null)
        {
            detalhes.AppendLine("\nInner Exception:");
            detalhes.AppendLine(FormatarExcecao(excecao.InnerException));
        }

        return detalhes.ToString();
    }
}
