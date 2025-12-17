using Domain.Entidades.Base;
using Domain.ObjetosDeValor;

namespace Domain.Entidades.Comum;

/// <summary>
/// Representa um depósito de materiais.
/// </summary>
public class Deposito : EntidadeBase
{
    /// <summary>
    /// Código único do depósito no sistema Infinity.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descrição do depósito (ex: "Depósito Central - KM 25").
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Coordenada geográfica do depósito.
    /// </summary>
    public Coordenada? Coordenada { get; set; }

    /// <summary>
    /// Indica se é um depósito pré-cadastrado (provisório).
    /// </summary>
    public bool Provisorio { get; set; }

    /// <summary>
    /// ID da obra à qual o depósito pertence (nullable para depósitos provisórios).
    /// </summary>
    public Guid? ObraId { get; set; }

    /// <summary>
    /// Navegação: Obra à qual o depósito pertence.
    /// </summary>
    public Obra? Obra { get; set; }

    /// <summary>
    /// Define a coordenada do depósito.
    /// </summary>
    public void DefinirCoordenada(decimal latitude, decimal longitude)
    {
        Coordenada = ObjetosDeValor.Coordenada.Criar(latitude, longitude);
        AtualizarDataAtualizacao();
    }

    /// <summary>
    /// Marca o depósito como pré-cadastrado.
    /// </summary>
    public void MarcarComoProvisorio()
    {
        Provisorio = true;
        AtualizarDataAtualizacao();
    }
}
