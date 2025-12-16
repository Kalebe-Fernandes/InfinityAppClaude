using Domain.Entidades.Comum;

namespace Domain.Interfaces.Repositorios;

/// <summary>
/// Interface para repositório de Depósitos.
/// </summary>
public interface IDepositoRepositorio : IRepositorio<Deposito>
{
    /// <summary>
    /// Obtém depósitos de uma obra específica.
    /// </summary>
    Task<IEnumerable<Deposito>> ObterDepositosPorObraAsync(Guid obraId);

    /// <summary>
    /// Obtém depósitos pré-cadastrados (provisórios).
    /// </summary>
    Task<IEnumerable<Deposito>> ObterDepositosProvisoriosAsync();

    /// <summary>
    /// Obtém um depósito pelo código.
    /// </summary>
    Task<Deposito?> ObterPorCodigoAsync(string codigo);
}