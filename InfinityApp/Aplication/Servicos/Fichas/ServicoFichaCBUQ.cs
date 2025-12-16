using Aplication.DTOs.Fichas;
using AutoMapper;
using Domain.Entidades.Fichas;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Fichas;

/// <summary>
/// Serviço de aplicação para Ficha de CBUQ.
/// </summary>
public class ServicoFichaCBUQ(IRepositorio<FichaCBUQ> repositorio, IUnitOfWork unitOfWork, IMapper mapper) : ServicoFichaBase<FichaCBUQ, FichaCBUQDto>(repositorio, unitOfWork, mapper)
{
}
