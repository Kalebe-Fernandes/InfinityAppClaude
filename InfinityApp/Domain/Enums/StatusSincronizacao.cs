namespace Domain.Enums;

/// <summary>
/// Representa o status de uma operação de sincronização.
/// </summary>
public enum StatusSincronizacao
{
    /// <summary>
    /// Sincronização aguardando para ser processada.
    /// </summary>
    Pendente = 0,

    /// <summary>
    /// Sincronização em andamento.
    /// </summary>
    EmProgresso = 1,

    /// <summary>
    /// Sincronização concluída com sucesso.
    /// </summary>
    Sucesso = 2,

    /// <summary>
    /// Sincronização falhou. Será tentada novamente.
    /// </summary>
    Erro = 3
}
