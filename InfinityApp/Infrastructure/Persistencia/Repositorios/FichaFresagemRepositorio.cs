using Domain.Entidades.Fichas;
using Infrastructure.Persistencia.Contexto;

namespace Infrastructure.Persistencia.Repositorios;

/// <summary>
/// Repositório específico para Ficha de Fresagem.
/// </summary>
public class FichaFresagemRepositorio(InfinityAppDbContext contexto) : FichaRepositorioBase<FichaFresagem>(contexto)
{
}
