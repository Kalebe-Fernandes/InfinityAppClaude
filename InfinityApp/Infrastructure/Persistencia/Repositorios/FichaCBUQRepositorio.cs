using Domain.Entidades.Fichas;
using Infrastructure.Persistencia.Contexto;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Repositório específico para Ficha de CBUQ.
/// </summary>
public class FichaCBUQRepositorio(InfinityAppDbContext contexto) : FichaRepositorioBase<FichaCBUQ>(contexto)
{
}
