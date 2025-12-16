using Domain.Entidades.Fichas;
using Infrastructure.Persistencia.Contexto;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Repositório específico para Ficha de Microrevestimento.
/// </summary>
public class FichaMicrorevestimentoRepositorio(InfinityAppDbContext contexto) : FichaRepositorioBase<FichaMicrorevestimento>(contexto)
{
}
