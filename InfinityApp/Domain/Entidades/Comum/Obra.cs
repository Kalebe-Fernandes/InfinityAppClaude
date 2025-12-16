using Domain.Entidades.Base;

namespace Domain.Entidades.Comum;

/// <summary>
/// Representa uma obra de infraestrutura rodoviária.
/// </summary>
public class Obra : EntidadeBase
{
    /// <summary>
    /// Código único da obra no sistema Infinity.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Nome completo da obra.
    /// </summary>
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Descrição detalhada da obra.
    /// </summary>
    public string? Descricao { get; set; }

    /// <summary>
    /// Data de início da obra.
    /// </summary>
    public DateTime DataInicio { get; set; }

    /// <summary>
    /// Data prevista para término da obra.
    /// </summary>
    public DateTime? DataFim { get; set; }

    /// <summary>
    /// Indica se a obra está ativa.
    /// </summary>
    public bool Ativa { get; set; }

    /// <summary>
    /// Navegação: Serviços da obra.
    /// </summary>
    public virtual ICollection<Servico> Servicos { get; set; } = [];

    /// <summary>
    /// Navegação: Trechos da obra.
    /// </summary>
    public virtual ICollection<Trecho> Trechos { get; set; } = [];

    /// <summary>
    /// Navegação: Equipamentos da obra.
    /// </summary>
    public virtual ICollection<Equipamento> Equipamentos { get; set; } = [];

    /// <summary>
    /// Navegação: Depósitos da obra.
    /// </summary>
    public virtual ICollection<Deposito> Depositos { get; set; } = [];

    /// <summary>
    /// Valida se a obra está ativa e dentro do período de execução.
    /// </summary>
    public bool EstaAtiva()
    {
        if (!Ativa)
            return false;

        var hoje = DateTime.Today;

        if (hoje < DataInicio.Date)
            return false;

        if (DataFim.HasValue && hoje > DataFim.Value.Date)
            return false;

        return true;
    }

    /// <summary>
    /// Ativa a obra.
    /// </summary>
    public void Ativar()
    {
        Ativa = true;
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Desativa a obra.
    /// </summary>
    public void Desativar()
    {
        Ativa = false;
        AtualizarDataAtualizacao();
    }
}
