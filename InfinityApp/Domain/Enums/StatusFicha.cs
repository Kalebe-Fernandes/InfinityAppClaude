namespace Domain.Enums;

/// <summary>
/// Representa os possíveis status de uma ficha de serviço.
/// </summary>
public enum StatusFicha
{
    /// <summary>
    /// Ficha criada mas ainda não finalizada. Permite edição.
    /// </summary>
    Pendente = 0,

    /// <summary>
    /// Ficha finalizada e pronta para sincronização. Não permite edição.
    /// Pode ser desfinalizada.
    /// </summary>
    Finalizada = 1,

    /// <summary>
    /// Ficha enviada com sucesso para o servidor. Não permite edição.
    /// </summary>
    Sincronizada = 2,

    /// <summary>
    /// Ficha cancelada. Não permite edição nem sincronização.
    /// </summary>
    Cancelada = 3
}
