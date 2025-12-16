using System.Linq.Expressions;
using Domain.Entidades.Base;

namespace Domain.Interfaces.Repositorios;

/// <summary>
/// Interface genérica para repositórios seguindo o padrão Repository.
/// Fornece operações básicas de CRUD para entidades do domínio.
/// </summary>
/// <typeparam name="T">Tipo da entidade que herda de EntidadeBase.</typeparam>
public interface IRepositorio<T> where T : EntidadeBase
{
    /// <summary>
    /// Obtém uma entidade por seu ID.
    /// </summary>
    /// <param name="id">ID da entidade.</param>
    /// <returns>Entidade encontrada ou null.</returns>
    Task<T?> ObterPorIdAsync(Guid id);

    /// <summary>
    /// Obtém todas as entidades.
    /// </summary>
    /// <returns>Lista de todas as entidades.</returns>
    Task<IEnumerable<T>> ObterTodosAsync();

    /// <summary>
    /// Busca entidades que atendem a um predicado.
    /// </summary>
    /// <param name="predicado">Expressão lambda para filtro.</param>
    /// <returns>Lista de entidades que atendem ao predicado.</returns>
    Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicado);

    /// <summary>
    /// Adiciona uma nova entidade.
    /// </summary>
    /// <param name="entidade">Entidade a ser adicionada.</param>
    Task AdicionarAsync(T entidade);

    /// <summary>
    /// Adiciona múltiplas entidades de uma vez.
    /// </summary>
    /// <param name="entidades">Coleção de entidades a serem adicionadas.</param>
    Task AdicionarVariasAsync(IEnumerable<T> entidades);

    /// <summary>
    /// Atualiza uma entidade existente.
    /// Método síncrono pois apenas marca a entidade como modificada no contexto.
    /// </summary>
    /// <param name="entidade">Entidade a ser atualizada.</param>
    void Atualizar(T entidade);

    /// <summary>
    /// Remove uma entidade.
    /// Método síncrono pois apenas marca a entidade para remoção no contexto.
    /// </summary>
    /// <param name="entidade">Entidade a ser removida.</param>
    void Remover(T entidade);

    /// <summary>
    /// Remove múltiplas entidades de uma vez.
    /// Método síncrono pois apenas marca as entidades para remoção no contexto.
    /// </summary>
    /// <param name="entidades">Coleção de entidades a serem removidas.</param>
    void RemoverVarias(IEnumerable<T> entidades);

    /// <summary>
    /// Verifica se existe alguma entidade que atende ao predicado.
    /// </summary>
    /// <param name="predicado">Expressão lambda para filtro.</param>
    /// <returns>True se existe, False caso contrário.</returns>
    Task<bool> ExisteAsync(Expression<Func<T, bool>> predicado);

    /// <summary>
    /// Conta quantas entidades atendem ao predicado.
    /// </summary>
    /// <param name="predicado">Expressão lambda para filtro.</param>
    /// <returns>Quantidade de entidades.</returns>
    Task<int> ContarAsync(Expression<Func<T, bool>> predicado);
}
