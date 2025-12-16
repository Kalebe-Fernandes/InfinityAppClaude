using Aplication.DTOs.Sincronizacao;

namespace Aplication.Servicos.Interfaces;

/// <summary>
/// Interface para serviço de sincronização.
/// </summary>
public interface ISincronizacaoService
{
    /// <summary>
    /// Executa a sincronização Pull (download de dados mestres).
    /// </summary>
    Task<ResultadoSincronizacaoDto> ExecutarPullAsync(Guid usuarioId, Guid? obraId = null);

    /// <summary>
    /// Executa a sincronização Push (upload de fichas finalizadas).
    /// </summary>
    Task<ResultadoSincronizacaoDto> ExecutarPushAsync(Guid usuarioId, Guid? obraId = null);

    /// <summary>
    /// Executa sincronização completa (Pull + Push).
    /// </summary>
    Task<ResultadoSincronizacaoDto> ExecutarSincronizacaoCompletaAsync(Guid usuarioId, Guid? obraId = null);

    /// <summary>
    /// Verifica se há fichas pendentes de sincronização.
    /// </summary>
    Task<bool> ExistemFichasPendentesAsync();

    /// <summary>
    /// Obtém a quantidade de fichas pendentes de sincronização.
    /// </summary>
    Task<int> ObterQuantidadeFichasPendentesAsync();

    /// <summary>
    /// Força o upload de emergência (executa Push independente do horário).
    /// </summary>
    Task<bool> ForcarUploadEmergenciaAsync(Guid fichaId);
}
