namespace Domain.Interfaces.Repositorios;

/// <summary>
/// Interface para o padrão Unit of Work.
/// Gerencia transações e coordena a persistência de múltiplas entidades.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Persiste todas as alterações pendentes no banco de dados.
    /// </summary>
    /// <returns>Número de registros afetados.</returns>
    Task<int> CommitAsync();

    /// <summary>
    /// Desfaz todas as alterações pendentes.
    /// </summary>
    Task RollbackAsync();

    /// <summary>
    /// Inicia uma nova transação.
    /// </summary>
    Task IniciarTransacaoAsync();

    /// <summary>
    /// Confirma a transação atual.
    /// </summary>
    Task ConfirmarTransacaoAsync();

    /// <summary>
    /// Reverte a transação atual.
    /// </summary>
    Task ReverterTransacaoAsync();
}
