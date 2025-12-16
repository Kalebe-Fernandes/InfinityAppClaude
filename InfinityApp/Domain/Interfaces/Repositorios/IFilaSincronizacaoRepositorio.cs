using Domain.Entidades.Sincronizacao;

namespace Domain.Interfaces.Repositorios;

/// <summary>
/// Interface para repositório de Fila de Sincronização.
/// </summary>
public interface IFilaSincronizacaoRepositorio : IRepositorio<FilaSincronizacao>
{
    /// <summary>
    /// Obtém itens pendentes de sincronização.
    /// </summary>
    Task<IEnumerable<FilaSincronizacao>> ObterItensPendentesAsync();

    /// <summary>
    /// Obtém itens com erro na sincronização.
    /// </summary>
    Task<IEnumerable<FilaSincronizacao>> ObterItensComErroAsync();

    /// <summary>
    /// Marca um item como sincronizado com sucesso.
    /// </summary>
    Task MarcarComoSincronizadoAsync(Guid fichaId);

    /// <summary>
    /// Marca um item como erro.
    /// </summary>
    Task MarcarComoErroAsync(Guid fichaId, string mensagemErro);

    /// <summary>
    /// Remove itens sincronizados com sucesso há mais de X dias.
    /// </summary>
    Task LimparItensAntigosAsync(int diasParaManter);
}
