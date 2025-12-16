using Aplication.DTOs.Fichas;
using AutoMapper;
using Domain.Entidades.Fichas;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Fichas;

/// <summary>
/// Serviço de aplicação para Ficha de Fresagem.
/// </summary>
public class ServicoFichaFresagem(
    IRepositorio<FichaFresagem> repositorio,
    IUnitOfWork unitOfWork,
    IMapper mapper) : ServicoFichaBase<FichaFresagem, FichaFresagemDto>(repositorio, unitOfWork, mapper)
{
}
