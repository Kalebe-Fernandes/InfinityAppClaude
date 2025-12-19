using Domain.Entidades.Logging;
using Domain.Enums;

namespace Domain.Interfaces.Servicos;

/// <summary>
/// Interface para serviço de logging completo do aplicativo.
/// Permite rastreamento detalhado de operações, erros e eventos.
/// </summary>
public interface IServicoLog
{
    /// <summary>
    /// Registra um log de nível Trace (mais detalhado).
    /// </summary>
    Task RegistrarTraceAsync(string origem, string mensagem, CategoriaLog categoria, object? contexto = null);

    /// <summary>
    /// Registra um log de nível Debug.
    /// </summary>
    Task RegistrarDebugAsync(string origem, string mensagem, CategoriaLog categoria, object? contexto = null);

    /// <summary>
    /// Registra um log de nível Information.
    /// </summary>
    Task RegistrarInformacaoAsync(string origem, string mensagem, CategoriaLog categoria, object? contexto = null);

    /// <summary>
    /// Registra um log de nível Warning.
    /// </summary>
    Task RegistrarAvisoAsync(string origem, string mensagem, CategoriaLog categoria, object? contexto = null);

    /// <summary>
    /// Registra um log de nível Error com exceção.
    /// </summary>
    Task RegistrarErroAsync(string origem, string mensagem, Exception excecao, CategoriaLog categoria, object? contexto = null);

    /// <summary>
    /// Registra um log de nível Fatal (erro crítico).
    /// </summary>
    Task RegistrarFatalAsync(string origem, string mensagem, Exception excecao, CategoriaLog categoria, object? contexto = null);

    /// <summary>
    /// Obtém logs filtrados por período.
    /// </summary>
    Task<IEnumerable<EntradaLog>> ObterLogsAsync(DateTime dataInicio, DateTime? dataFim = null);

    /// <summary>
    /// Obtém logs filtrados por nível.
    /// </summary>
    Task<IEnumerable<EntradaLog>> ObterLogsPorNivelAsync(NivelLog nivel);

    /// <summary>
    /// Obtém logs filtrados por categoria.
    /// </summary>
    Task<IEnumerable<EntradaLog>> ObterLogsPorCategoriaAsync(CategoriaLog categoria);

    /// <summary>
    /// Limpa logs mais antigos que a data especificada.
    /// </summary>
    Task LimparLogsAntigosAsync(DateTime dataLimite);

    /// <summary>
    /// Exporta logs para um arquivo texto.
    /// </summary>
    Task<string> ExportarLogsAsync(DateTime dataInicio, DateTime? dataFim = null);

    /// <summary>
    /// Obtém estatísticas de logs (contagens por nível/categoria).
    /// </summary>
    Task<EstatisticasLog> ObterEstatisticasAsync(DateTime dataInicio, DateTime? dataFim = null);
}
