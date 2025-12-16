using Domain.Entidades.Fichas;
using Infrastructure.Persistencia.Contexto;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Repositório específico para Ficha de Bota Dentro.
/// </summary>
public class FichaBotaDentroRepositorio(InfinityAppDbContext contexto) : FichaRepositorioBase<FichaBotaDentro>(contexto)
{
}
