using AutoMapper;
using Aplication.DTOs.Autenticacao;
using Aplication.DTOs.Fichas;
using Aplication.DTOs.Sincronizacao;
using Aplication.DTOs;
using Domain.Entidades.Comum;
using Domain.Entidades.Fichas;
using Domain.Entidades.Apontamentos;
using Domain.Entidades.Sincronizacao;

namespace InfinityApp.Application.Mapeamentos;

/// <summary>
/// Perfil do AutoMapper com mapeamentos entre entidades e DTOs.
/// </summary>
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        ConfigurarMapeamentosComuns();
        ConfigurarMapeamentosFichas();
        ConfigurarMapeamentosApontamentos();
        ConfigurarMapeamentosSincronizacao();
        ConfigurarMapeamentosAutenticacao();
    }

    private void ConfigurarMapeamentosComuns()
    {
        CreateMap<Obra, ObraDto>().ReverseMap();
        CreateMap<Servico, ServicoDto>().ReverseMap();
        CreateMap<Trecho, TrechoDto>()
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo.ToString()))
            .ReverseMap();

        CreateMap<Material, MaterialDto>().ReverseMap();

        CreateMap<Equipamento, EquipamentoDto>()
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo.ToString()))
            .ReverseMap();

        CreateMap<Deposito, DepositoDto>()
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Coordenada != null ? src.Coordenada.Latitude : (double?)null))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Coordenada != null ? src.Coordenada.Longitude : (double?)null));

        CreateMap<DepositoDto, Deposito>()
            .ForMember(dest => dest.Coordenada, opt => opt.Ignore());
    }

    private void ConfigurarMapeamentosFichas()
    {
        // Ficha Limpeza Pista
        CreateMap<FichaLimpezaPista, FichaLimpezaPistaDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.Pista, opt => opt.MapFrom(src => src.Pista.HasValue ? src.Pista.ToString() : null))
            .ForMember(dest => dest.ObraNome, opt => opt.MapFrom(src => src.Obra.Nome))
            .ForMember(dest => dest.ServicoDescricao, opt => opt.MapFrom(src => src.Servico.Descricao))
            .ForMember(dest => dest.TrechoDescricao, opt => opt.MapFrom(src => src.Trecho.Descricao))
            .ForMember(dest => dest.EquipamentoDescricao, opt => opt.MapFrom(src => src.EquipamentoExecucao.Descricao));

        CreateMap<FichaLimpezaPistaDto, FichaLimpezaPista>()
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.Pista, opt => opt.Ignore())
            .ForMember(dest => dest.Obra, opt => opt.Ignore())
            .ForMember(dest => dest.Servico, opt => opt.Ignore())
            .ForMember(dest => dest.Trecho, opt => opt.Ignore())
            .ForMember(dest => dest.EquipamentoExecucao, opt => opt.Ignore())
            .ForMember(dest => dest.Apontamentos, opt => opt.Ignore());

        // Ficha Viagem CB
        CreateMap<FichaViagemCB, FichaViagemCBDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.Pista, opt => opt.MapFrom(src => src.Pista.HasValue ? src.Pista.ToString() : null))
            .ForMember(dest => dest.ObraNome, opt => opt.MapFrom(src => src.Obra.Nome))
            .ForMember(dest => dest.ServicoDescricao, opt => opt.MapFrom(src => src.Servico.Descricao))
            .ForMember(dest => dest.TrechoDescricao, opt => opt.MapFrom(src => src.Trecho.Descricao))
            .ForMember(dest => dest.EquipamentoDescricao, opt => opt.MapFrom(src => src.EquipamentoExecucao.Descricao))
            .ForMember(dest => dest.DepositoOrigemDescricao, opt => opt.MapFrom(src => src.DepositoOrigem != null ? src.DepositoOrigem.Descricao : null))
            .ForMember(dest => dest.DepositoDestinoDescricao, opt => opt.MapFrom(src => src.DepositoDestino != null ? src.DepositoDestino.Descricao : null));

        CreateMap<FichaViagemCBDto, FichaViagemCB>()
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.Pista, opt => opt.Ignore())
            .ForMember(dest => dest.Obra, opt => opt.Ignore())
            .ForMember(dest => dest.Servico, opt => opt.Ignore())
            .ForMember(dest => dest.Trecho, opt => opt.Ignore())
            .ForMember(dest => dest.EquipamentoExecucao, opt => opt.Ignore())
            .ForMember(dest => dest.DepositoOrigem, opt => opt.Ignore())
            .ForMember(dest => dest.DepositoDestino, opt => opt.Ignore())
            .ForMember(dest => dest.Equipamentos, opt => opt.Ignore())
            .ForMember(dest => dest.Apontamentos, opt => opt.Ignore());

        // Demais fichas (simplificado)
        CreateMap<FichaBotaDentro, FichaBotaDentroDto>().ReverseMap();
        CreateMap<FichaFresagem, FichaFresagemDto>().ReverseMap();
        CreateMap<FichaCBUQ, FichaCBUQDto>().ReverseMap();
        CreateMap<FichaMicrorevestimento, FichaMicrorevestimentoDto>().ReverseMap();
    }

    private void ConfigurarMapeamentosApontamentos()
    {
        CreateMap<ApontamentoLimpezaPista, ApontamentoLimpezaPistaDto>()
            .ForMember(dest => dest.Lado, opt => opt.MapFrom(src => src.Lado.ToString()))
            .ReverseMap();

        CreateMap<ApontamentoViagemCB, ApontamentoViagemCBDto>()
            .ForMember(dest => dest.EquipamentoDescricao, opt => opt.MapFrom(src => src.Equipamento.Descricao))
            .ForMember(dest => dest.MaterialDescricao, opt => opt.MapFrom(src => src.Material.Descricao))
            .ReverseMap();

        CreateMap<ApontamentoBotaDentro, ApontamentoBotaDentroDto>()
            .ForMember(dest => dest.MaterialDescricao, opt => opt.MapFrom(src => src.Material.Descricao))
            .ReverseMap();

        CreateMap<ApontamentoFresagem, ApontamentoFresagemDto>()
            .ForMember(dest => dest.Lado, opt => opt.MapFrom(src => src.Lado.ToString()))
            .ReverseMap();

        CreateMap<ApontamentoCBUQ, ApontamentoCBUQDto>()
            .ForMember(dest => dest.Lado, opt => opt.MapFrom(src => src.Lado.ToString()))
            .ReverseMap();

        CreateMap<ApontamentoMicrorevestimento, ApontamentoMicrorevestimentoDto>()
            .ForMember(dest => dest.Lado, opt => opt.MapFrom(src => src.Lado.ToString()))
            .ReverseMap();
    }

    private void ConfigurarMapeamentosSincronizacao()
    {
        CreateMap<HistoricoSincronizacao, HistoricoSincronizacaoDto>()
            .ForMember(dest => dest.UsuarioNome, opt => opt.MapFrom(src => src.Usuario.Nome))
            .ForMember(dest => dest.ObraNome, opt => opt.MapFrom(src => src.Obra != null ? src.Obra.Nome : null))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
    }

    private void ConfigurarMapeamentosAutenticacao()
    {
        CreateMap<Usuario, UsuarioDto>().ReverseMap();
    }
}
