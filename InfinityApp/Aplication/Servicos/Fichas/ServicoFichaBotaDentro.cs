using Aplication.DTOs.Fichas;
using AutoMapper;
using Domain.Entidades.Fichas;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Fichas;

/// <summary>
/// Serviço de aplicação para Ficha de Bota Dentro.
/// </summary>
public class ServicoFichaBotaDentro(IRepositorio<FichaBotaDentro> repositorio, IUnitOfWork unitOfWork, IMapper mapper) : ServicoFichaBase<FichaBotaDentro, FichaBotaDentroDto>(repositorio, unitOfWork, mapper)
{
}
