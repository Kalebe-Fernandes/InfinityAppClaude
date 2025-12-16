namespace Domain.Enums;

/// <summary>
/// Representa o tipo de operação realizada em uma entidade.
/// Utilizado para rastreamento de alterações e sincronização.
/// </summary>
public enum TipoOperacao
{
    /// <summary>
    /// Operação de criação de novo registro.
    /// </summary>
    Criar = 0,

    /// <summary>
    /// Operação de atualização de registro existente.
    /// </summary>
    Atualizar = 1,

    /// <summary>
    /// Operação de exclusão de registro.
    /// </summary>
    Excluir = 2
}
