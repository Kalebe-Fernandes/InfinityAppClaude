namespace Domain.Entidades.Base;

/// <summary>
/// Classe base para todas as entidades do domínio.
/// Fornece propriedades comuns para rastreamento e sincronização.
/// </summary>
public abstract class EntidadeBase
{
    /// <summary>
    /// Identificador único da entidade.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Data e hora de criação do registro.
    /// </summary>
    public DateTime DataCriacao { get; set; }

    /// <summary>
    /// Data e hora da última atualização do registro.
    /// </summary>
    public DateTime DataAtualizacao { get; set; }

    /// <summary>
    /// Construtor padrão que inicializa Id e datas.
    /// </summary>
    protected EntidadeBase()
    {
        Id = Guid.NewGuid();
        DataCriacao = DateTime.UtcNow;
        DataAtualizacao = DateTime.UtcNow;
    }

    /// <summary>
    /// Atualiza a data de atualização para o momento atual.
    /// Deve ser chamado sempre que a entidade for modificada.
    /// </summary>
    public void AtualizarDataAtualizacao()
    {
        DataAtualizacao = DateTime.UtcNow;
    }

    /// <summary>
    /// Determina se dois objetos EntidadeBase são iguais comparando seus IDs.
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is not EntidadeBase entidade)
            return false;

        if (ReferenceEquals(this, entidade))
            return true;

        if (GetType() != entidade.GetType())
            return false;

        return Id == entidade.Id;
    }

    /// <summary>
    /// Retorna o código hash baseado no ID da entidade.
    /// </summary>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// Operador de igualdade.
    /// </summary>
    public static bool operator ==(EntidadeBase? a, EntidadeBase? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    /// <summary>
    /// Operador de desigualdade.
    /// </summary>
    public static bool operator !=(EntidadeBase? a, EntidadeBase? b)
    {
        return !(a == b);
    }
}
