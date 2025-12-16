namespace Domain.Interfaces.Servicos;

/// <summary>
/// Interface para serviço de cache em memória.
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// Obtém um item do cache.
    /// </summary>
    T? Obter<T>(string chave) where T : class;

    /// <summary>
    /// Adiciona ou atualiza um item no cache.
    /// </summary>
    void Adicionar<T>(string chave, T valor, TimeSpan? tempoExpiracao = null) where T : class;

    /// <summary>
    /// Remove um item do cache.
    /// </summary>
    void Remover(string chave);

    /// <summary>
    /// Limpa todo o cache.
    /// </summary>
    void LimparTudo();

    /// <summary>
    /// Verifica se uma chave existe no cache.
    /// </summary>
    bool Existe(string chave);
}
