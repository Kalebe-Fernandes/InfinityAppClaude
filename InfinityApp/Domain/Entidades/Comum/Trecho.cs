using Domain.Entidades.Base;
using Domain.Enums;

namespace Domain.Entidades.Comum;

/// <summary>
/// Representa um trecho de rodovia dentro de uma obra.
/// </summary>
public class Trecho : EntidadeBase
{
    /// <summary>
    /// Código único do trecho no sistema Infinity.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descrição do trecho (ex: "Trecho 1 - Estaca 0+000 a 10+000").
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Tipo de referência utilizado no trecho (Estaca ou Quilômetro).
    /// </summary>
    public TipoReferencia Tipo { get; set; }

    /// <summary>
    /// Indica se o trecho possui pista dupla.
    /// </summary>
    public bool PistaDupla { get; set; }

    /// <summary>
    /// Indica se o trecho está completo, com os serviços todos feitos.
    /// </summary>
    public bool EstaCompleto { get; set; }

    /// <summary>
    /// Estaca ou KM inicial do trecho.
    /// </summary>
    public decimal? EstacaInicial { get; set; }

    /// <summary>
    /// Estaca ou KM final do trecho.
    /// </summary>
    public decimal? EstacaFinal { get; set; }

    /// <summary>
    /// ID da obra à qual o trecho pertence.
    /// </summary>
    public Guid ObraId { get; set; }

    /// <summary>
    /// Navegação: Obra à qual o trecho pertence.
    /// </summary>
    public Obra Obra { get; set; } = null!;

    /// <summary>
    /// Valida se o trecho possui pista dupla e exige seleção de pista.
    /// </summary>
    public bool RequerSelecaoPista()
    {
        return PistaDupla;
    }

    /// <summary>
    /// Obtém a extensão total do trecho em metros (se estaca) ou km.
    /// </summary>
    public decimal? ObterExtensao()
    {
        if (!EstacaInicial.HasValue || !EstacaFinal.HasValue)
            return null;

        if (Tipo == TipoReferencia.Estaca)
            return (EstacaFinal.Value - EstacaInicial.Value) * 20; // Cada estaca = 20 metros

        return EstacaFinal.Value - EstacaInicial.Value; // KM
    }

    public bool EstaAtivoComObraAtiva()
    {
        return Obra.Ativa && !EstaCompleto;
    }

    public bool EstaAtivoSemObra()
    {
        return !EstaCompleto && Obra == null;
    }
}
