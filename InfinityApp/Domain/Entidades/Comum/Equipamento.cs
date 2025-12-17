using Domain.Entidades.Base;
using Domain.Enums;

namespace Domain.Entidades.Comum;

/// <summary>
/// Representa um equipamento utilizado nos serviços.
/// </summary>
public class Equipamento : EntidadeBase
{
    /// <summary>
    /// Código único do equipamento no sistema Infinity.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descrição do equipamento (ex: "Motoniveladora CAT 140K").
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Tipo do equipamento (Execução, Transporte ou Ambos).
    /// </summary>
    public TipoEquipamento Tipo { get; set; }

    /// <summary>
    /// Capacidade do equipamento em m³ (para equipamentos de transporte).
    /// </summary>
    public decimal? Capacidade { get; set; }

    /// <summary>
    /// Placa do equipamento.
    /// </summary>
    public string? Placa { get; set; }

    /// <summary>
    /// Indica se é um equipamento pré-cadastrado (provisório).
    /// </summary>
    public bool Provisorio { get; set; }

    /// <summary>
    /// ID da obra à qual o equipamento pertence (nullable para equipamentos provisórios).
    /// </summary>
    public Guid? ObraId { get; set; }

    /// <summary>
    /// Navegação: Obra à qual o equipamento pertence.
    /// </summary>
    public Obra? Obra { get; set; }
    public string? Prefixo { get; set; }

    /// <summary>
    /// Verifica se o equipamento pode ser usado para execução.
    /// </summary>
    public bool PodeExecutar()
    {
        return Tipo == TipoEquipamento.Execucao || Tipo == TipoEquipamento.Ambos;
    }

    /// <summary>
    /// Verifica se o equipamento pode ser usado para transporte.
    /// </summary>
    public bool PodeTransportar()
    {
        return Tipo == TipoEquipamento.Transporte || Tipo == TipoEquipamento.Ambos;
    }

    /// <summary>
    /// Marca o equipamento como pré-cadastrado.
    /// </summary>
    public void MarcarComoProvisorio()
    {
        Provisorio = true;
        AtualizarDataAtualizacao();
    }
}
