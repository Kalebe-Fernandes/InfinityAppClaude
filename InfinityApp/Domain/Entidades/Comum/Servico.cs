using Domain.Entidades.Base;

namespace Domain.Entidades.Comum;

/// <summary>
/// Representa um tipo de serviço executado em uma obra.
/// </summary>
public class Servico : EntidadeBase
{
    /// <summary>
    /// Código único do serviço no sistema Infinity.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descrição do serviço (ex: "Limpeza de Pista", "Transporte de Material CB").
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Unidade de medida do serviço (ex: "m²", "m³", "km").
    /// </summary>
    public string Unidade { get; set; } = string.Empty;

    /// <summary>
    /// Indica se o serviço está ativo.
    /// </summary>
    public bool Ativo { get; set; }

    /// <summary>
    /// ID da obra à qual o serviço pertence.
    /// </summary>
    public Guid ObraId { get; set; }

    /// <summary>
    /// Navegação: Obra à qual o serviço pertence.
    /// </summary>
    public Obra Obra { get; set; } = null!;

    /// <summary>
    /// Navegação: Materiais utilizados neste serviço.
    /// </summary>
    public ICollection<Material> Materiais { get; set; } = [];

    /// <summary>
    /// Ativa o serviço.
    /// </summary>
    public void Ativar()
    {
        Ativo = true;
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Desativa o serviço.
    /// </summary>
    public void Desativar()
    {
        Ativo = false;
        AtualizarDataAtualizacao();
    }
}
