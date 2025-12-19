namespace Domain.Enums;

/// <summary>
/// Categorias de log para classificação e filtragem.
/// </summary>
public enum CategoriaLog
{
    /// <summary>
    /// Categoria geral para logs não classificados.
    /// </summary>
    Geral = 0,

    /// <summary>
    /// Logs relacionados a autenticação e autorização.
    /// </summary>
    Autenticacao = 1,

    /// <summary>
    /// Logs relacionados a sincronização de dados.
    /// </summary>
    Sincronizacao = 2,

    /// <summary>
    /// Logs relacionados a persistência local (SQLite).
    /// </summary>
    Persistencia = 3,

    /// <summary>
    /// Logs relacionados a navegação entre telas.
    /// </summary>
    Navegacao = 4,

    /// <summary>
    /// Logs relacionados a interações de UI.
    /// </summary>
    UI = 5,

    /// <summary>
    /// Logs relacionados a chamadas de API.
    /// </summary>
    API = 6,

    /// <summary>
    /// Logs relacionados a validações de negócio.
    /// </summary>
    Validacao = 7,

    /// <summary>
    /// Logs relacionados a performance e métricas.
    /// </summary>
    Performance = 8
}
