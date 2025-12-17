using Aplication.Servicos.Interfaces;
using Domain.Entidades.Comum;
using Domain.Enums;
using Domain.Interfaces.Repositorios;

namespace Aplication.Servicos.Sincronizacao;

/// <summary>
/// Serviço de sincronização Pull (download de dados mestres da API).
/// </summary>
public class ServicoSincronizacaoPull(IApiInfinityClient apiClient, IUnitOfWork unitOfWork, IObraRepositorio obraRepositorio, IServicoRepositorio servicoRepositorio, ITrechoRepositorio trechoRepositorio, IMaterialRepositorio materialRepositorio, IEquipamentoRepositorio equipamentoRepositorio, IDepositoRepositorio depositoRepositorio)
{
    private readonly IApiInfinityClient _apiClient = apiClient;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IObraRepositorio _obraRepositorio = obraRepositorio;
    private readonly IServicoRepositorio _servicoRepositorio = servicoRepositorio;
    private readonly ITrechoRepositorio _trechoRepositorio = trechoRepositorio;
    private readonly IMaterialRepositorio _materialRepositorio = materialRepositorio;
    private readonly IEquipamentoRepositorio _equipamentoRepositorio = equipamentoRepositorio;
    private readonly IDepositoRepositorio _depositoRepositorio = depositoRepositorio;

    /// <summary>
    /// Sincroniza todos os dados mestres da API.
    /// </summary>
    public async Task<ResultadoSincronizacaoPull> SincronizarTudoAsync(IProgress<ProgressoSincronizacao>? progress = null, CancellationToken cancellationToken = default)
    {
        var resultado = new ResultadoSincronizacaoPull
        {
            DataInicio = DateTime.UtcNow
        };

        try
        {
            // 1. Obras
            ReportarProgresso(progress, "Sincronizando obras...", 0, 6);
            resultado.QuantidadeObras = await SincronizarObrasAsync(cancellationToken);

            // 2. Materiais (independente de obra)
            ReportarProgresso(progress, "Sincronizando materiais...", 1, 6);
            resultado.QuantidadeMateriais = await SincronizarMateriaisAsync(cancellationToken);

            // 3. Equipamentos (independente de obra)
            ReportarProgresso(progress, "Sincronizando equipamentos...", 2, 6);
            resultado.QuantidadeEquipamentos = await SincronizarEquipamentosAsync(cancellationToken);

            // 4. Depósitos
            ReportarProgresso(progress, "Sincronizando depósitos...", 3, 6);
            resultado.QuantidadeDepositos = await SincronizarDepositosAsync(cancellationToken);

            // 5. Serviços (por obra)
            ReportarProgresso(progress, "Sincronizando serviços...", 4, 6);
            resultado.QuantidadeServicos = await SincronizarServicosAsync(cancellationToken);

            // 6. Trechos (por obra)
            ReportarProgresso(progress, "Sincronizando trechos...", 5, 6);
            resultado.QuantidadeTrechos = await SincronizarTrechosAsync(cancellationToken);

            resultado.Sucesso = true;
            resultado.DataFim = DateTime.UtcNow;

            ReportarProgresso(progress, "Sincronização concluída!", 6, 6);
        }
        catch (Exception ex)
        {
            resultado.Sucesso = false;
            resultado.MensagemErro = ex.Message;
            resultado.DataFim = DateTime.UtcNow;

            ReportarProgresso(progress, $"Erro: {ex.Message}", 6, 6);
        }

        return resultado;
    }

    /// <summary>
    /// Sincroniza apenas as obras.
    /// </summary>
    private async Task<int> SincronizarObrasAsync(CancellationToken cancellationToken)
    {
        var obrasApi = await _apiClient.ObterObrasAsync(cancellationToken);
        var contador = 0;

        foreach (var obraApi in obrasApi)
        {
            var obraExistente = await _obraRepositorio.ObterPorCodigoAsync(obraApi.Codigo);

            if (obraExistente != null)
            {
                // Atualizar obra existente
                obraExistente.Nome = obraApi.Nome;
                obraExistente.Descricao = obraApi.Descricao;
                obraExistente.DataInicio = obraApi.DataInicio;
                obraExistente.DataFim = obraApi.DataFim;

                if (obraApi.Ativa)
                    obraExistente.Ativar();
                else
                    obraExistente.Desativar();

                await _obraRepositorio.Atualizar(obraExistente);
            }
            else
            {
                // Criar nova obra
                var novaObra = new Obra
                {
                    Codigo = obraApi.Codigo,
                    Numero = obraApi.Numero,
                    Nome = obraApi.Nome,
                    Descricao = obraApi.Descricao,
                    DataInicio = obraApi.DataInicio,
                    DataFim = obraApi.DataFim,
                    Ativa = obraApi.Ativa
                };

                await _obraRepositorio.AdicionarAsync(novaObra);
            }

            contador++;
        }

        await _unitOfWork.CommitAsync();
        return contador;
    }

    /// <summary>
    /// Sincroniza serviços de todas as obras.
    /// </summary>
    private async Task<int> SincronizarServicosAsync(CancellationToken cancellationToken)
    {
        var obras = await _obraRepositorio.ObterTodosAsync();
        var contador = 0;

        foreach (var obra in obras)
        {
            var servicosApi = await _apiClient.ObterServicosAsync(obra.Codigo, cancellationToken);

            foreach (var servicoApi in servicosApi)
            {
                var servicoExistente = await _servicoRepositorio.ObterPorCodigoAsync(servicoApi.Codigo);

                if (servicoExistente != null)
                {
                    servicoExistente.Descricao = servicoApi.Descricao;
                    servicoExistente.Unidade = servicoApi.Unidade;
                    servicoExistente.ObraId = obra.Id;

                    if (servicoApi.Ativo)
                        servicoExistente.Ativar();
                    else
                        servicoExistente.Desativar();

                    await _servicoRepositorio.Atualizar(servicoExistente);
                }
                else
                {
                    var novoServico = new Servico
                    {
                        Codigo = servicoApi.Codigo,
                        Descricao = servicoApi.Descricao,
                        Unidade = servicoApi.Unidade,
                        ObraId = obra.Id,
                        Ativo = servicoApi.Ativo
                    };

                    await _servicoRepositorio.AdicionarAsync(novoServico);
                }

                contador++;
            }
        }

        await _unitOfWork.CommitAsync();
        return contador;
    }

    /// <summary>
    /// Sincroniza trechos de todas as obras.
    /// </summary>
    private async Task<int> SincronizarTrechosAsync(CancellationToken cancellationToken)
    {
        var obras = await _obraRepositorio.ObterObrasAtivasAsync();
        var contador = 0;

        foreach (var obra in obras)
        {
            var trechosApi = await _apiClient.ObterTrechosAsync(obra.Codigo, cancellationToken);

            foreach (var trechoApi in trechosApi)
            {
                var trechoExistente = await _trechoRepositorio.ObterPorCodigoAsync(trechoApi.Codigo);

                if (trechoExistente != null)
                {
                    trechoExistente.Descricao = trechoApi.Descricao;
                    trechoExistente.Tipo = Enum.Parse<TipoReferencia>(trechoApi.Tipo);
                    trechoExistente.PistaDupla = trechoApi.PistaDupla;
                    trechoExistente.EstacaInicial = trechoApi.EstacaInicial;
                    trechoExistente.EstacaFinal = trechoApi.EstacaFinal;
                    trechoExistente.ObraId = obra.Id;

                    await _trechoRepositorio.Atualizar(trechoExistente);
                }
                else
                {
                    var novoTrecho = new Trecho
                    {
                        Codigo = trechoApi.Codigo,
                        Descricao = trechoApi.Descricao,
                        Tipo = Enum.Parse<TipoReferencia>(trechoApi.Tipo),
                        PistaDupla = trechoApi.PistaDupla,
                        EstacaInicial = trechoApi.EstacaInicial,
                        EstacaFinal = trechoApi.EstacaFinal,
                        ObraId = obra.Id
                    };

                    await _trechoRepositorio.AdicionarAsync(novoTrecho);
                }

                contador++;
            }
        }

        await _unitOfWork.CommitAsync();
        return contador;
    }

    /// <summary>
    /// Sincroniza materiais.
    /// </summary>
    private async Task<int> SincronizarMateriaisAsync(CancellationToken cancellationToken)
    {
        var materiaisApi = await _apiClient.ObterMateriaisAsync(cancellationToken);
        var contador = 0;

        foreach (var materialApi in materiaisApi)
        {
            var materialExistente = await _materialRepositorio.ObterPorCodigoAsync(materialApi.Codigo);

            if (materialExistente != null)
            {
                materialExistente.Descricao = materialApi.Descricao;
                materialExistente.Unidade = materialApi.Unidade;
                await _materialRepositorio.Atualizar(materialExistente);
            }
            else
            {
                var novoMaterial = new Material
                {
                    Codigo = materialApi.Codigo,
                    Descricao = materialApi.Descricao,
                    Unidade = materialApi.Unidade
                };

                await _materialRepositorio.AdicionarAsync(novoMaterial);
            }

            contador++;
        }

        await _unitOfWork.CommitAsync();
        return contador;
    }

    /// <summary>
    /// Sincroniza equipamentos.
    /// </summary>
    private async Task<int> SincronizarEquipamentosAsync(CancellationToken cancellationToken)
    {
        var equipamentosApi = await _apiClient.ObterEquipamentosAsync(cancellationToken);
        var contador = 0;

        foreach (var equipamentoApi in equipamentosApi)
        {
            var equipamentoExistente = await _equipamentoRepositorio.ObterPorPlacaAsync(equipamentoApi.Codigo);
            if (equipamentoExistente != null)
            {
                equipamentoExistente.Prefixo = equipamentoApi.Prefixo;
                equipamentoExistente.Placa = equipamentoApi.Placa;
                equipamentoExistente.Tipo = Enum.Parse<TipoEquipamento>(equipamentoApi.Tipo);
                equipamentoExistente.Capacidade = equipamentoApi.Capacidade;
                equipamentoExistente.Provisorio = equipamentoApi.Provisorio;

                await _equipamentoRepositorio.Atualizar(equipamentoExistente);
            }
            else
            {
                var novoEquipamento = new Equipamento
                {
                    Codigo = equipamentoApi.Codigo,
                    Prefixo = equipamentoApi.Prefixo,
                    Placa = equipamentoApi.Placa,
                    Tipo = Enum.Parse<TipoEquipamento>(equipamentoApi.Tipo),
                    Capacidade = equipamentoApi.Capacidade,
                    Provisorio = equipamentoApi.Provisorio
                };

                await _equipamentoRepositorio.AdicionarAsync(novoEquipamento);
            }

            contador++;
        }

        await _unitOfWork.CommitAsync();
        return contador;
    }

    /// <summary>
    /// Sincroniza depósitos.
    /// </summary>
    private async Task<int> SincronizarDepositosAsync(CancellationToken cancellationToken)
    {
        var depositosApi = await _apiClient.ObterDepositosAsync(cancellationToken);
        var contador = 0;

        foreach (var depositoApi in depositosApi)
        {
            var depositoExistente = await _depositoRepositorio.ObterPorCodigoAsync(depositoApi.Codigo);

            if (depositoExistente != null)
            {
                depositoExistente.Nome = depositoApi.Nome;
                depositoExistente.Descricao = depositoApi.Descricao!;
                depositoExistente.Provisorio = depositoApi.Provisorio;

                if (depositoApi.Latitude.HasValue && depositoApi.Longitude.HasValue)
                {
                    depositoExistente.DefinirCoordenada(
                        depositoApi.Latitude.Value,
                        depositoApi.Longitude.Value
                    );
                }

                await _depositoRepositorio.Atualizar(depositoExistente);
            }
            else
            {
                var novoDeposito = new Deposito
                {
                    Codigo = depositoApi.Codigo,
                    Nome = depositoApi.Nome,
                    Descricao = depositoApi.Descricao!,
                    Provisorio = depositoApi.Provisorio
                };

                if (depositoApi.Latitude.HasValue && depositoApi.Longitude.HasValue)
                {
                    novoDeposito.DefinirCoordenada(
                        depositoApi.Latitude.Value,
                        depositoApi.Longitude.Value
                    );
                }

                await _depositoRepositorio.AdicionarAsync(novoDeposito);
            }

            contador++;
        }

        await _unitOfWork.CommitAsync();
        return contador;
    }

    /// <summary>
    /// Reporta progresso da sincronização.
    /// </summary>
    private void ReportarProgresso(IProgress<ProgressoSincronizacao>? progress, string mensagem, int atual, int total)
    {
        progress?.Report(new ProgressoSincronizacao
        {
            Mensagem = mensagem,
            ItemAtual = atual,
            TotalItens = total,
            Porcentagem = (int)(atual / (double)total * 100)
        });
    }
}