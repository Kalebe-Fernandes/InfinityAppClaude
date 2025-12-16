using Aplication.DTOs.Fichas;
using AutoMapper;
using Domain.Entidades.Fichas;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Fichas;

/// <summary>
/// Serviço de aplicação para Ficha de Microrevestimento.
/// </summary>
public class ServicoFichaMicrorevestimento(
    IRepositorio<FichaMicrorevestimento> repositorio,
    IUnitOfWork unitOfWork,
    IMapper mapper) : ServicoFichaBase<FichaMicrorevestimento, FichaMicrorevestimentoDto>(repositorio, unitOfWork, mapper)
{
}
