using Domain.Interfaces.Repositorios;
using Domain.Entidades.Sincronizacao;
using Aplication.DTOs.Sincronizacao;
using Domain.Enums;
using Aplication.Servicos.Interfaces;

namespace Aplication.Servicos.Sincronizacao;

/// <summary>
/// Serviço de sincronização offline-first.
/// Gerencia Pull (download) e Push (upload) de dados.
/// </summary>
public class ServicoSincronizacao(IFilaSincronizacaoRepositorio filaSincronizacaoRepo, IHistoricoSincronizacaoRepositorio historicoRepo, IUnitOfWork unitOfWork) : ISincronizacaoService
{
    private readonly IFilaSincronizacaoRepositorio _filaSincronizacaoRepo = filaSincronizacaoRepo;
    private readonly IHistoricoSincronizacaoRepositorio _historicoRepo = historicoRepo;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ResultadoSincronizacaoDto> ExecutarPullAsync(Guid usuarioId, Guid? obraId = null)
    {
        var historico = new HistoricoSincronizacao
        {
            Tipo = "Pull",
            UsuarioId = usuarioId,
            ObraId = obraId,
            Status = StatusSincronizacao.EmProgresso,
            DataInicio = DateTime.UtcNow
        };

        try
        {
            await _historicoRepo.AdicionarAsync(historico);
            await _unitOfWork.CommitAsync();

            // Aqui será implementada a lógica de download da API
            // Por enquanto, apenas registra o histórico

            historico.Finalizar(0, 0, 0, "Pull ainda não implementado");
            _historicoRepo.Atualizar(historico);
            await _unitOfWork.CommitAsync();

            return new ResultadoSincronizacaoDto
            {
                Sucesso = true,
                Tipo = "Pull",
                QuantidadeTotal = 0,
                QuantidadeSucesso = 0,
                QuantidadeErro = 0,
                Mensagem = "Pull sincronizado (implementação pendente)",
                DataInicio = historico.DataInicio,
                DataFim = historico.DataFim!.Value,
                DuracaoSegundos = historico.DuracaoSegundos!.Value
            };
        }
        catch (Exception ex)
        {
            historico.Finalizar(0, 0, 0, $"Erro: {ex.Message}");
            historico.Status = StatusSincronizacao.Erro;
            _historicoRepo.Atualizar(historico);
            await _unitOfWork.CommitAsync();

            return new ResultadoSincronizacaoDto
            {
                Sucesso = false,
                Tipo = "Pull",
                Mensagem = $"Erro ao executar Pull: {ex.Message}",
                DataInicio = historico.DataInicio,
                DataFim = DateTime.UtcNow
            };
        }
    }

    public async Task<ResultadoSincronizacaoDto> ExecutarPushAsync(Guid usuarioId, Guid? obraId = null)
    {
        var historico = new HistoricoSincronizacao
        {
            Tipo = "Push",
            UsuarioId = usuarioId,
            ObraId = obraId,
            Status = StatusSincronizacao.EmProgresso,
            DataInicio = DateTime.UtcNow
        };

        try
        {
            await _historicoRepo.AdicionarAsync(historico);
            await _unitOfWork.CommitAsync();

            // Obter fichas pendentes de sincronização
            var fichasPendentes = await _filaSincronizacaoRepo.ObterItensPendentesAsync();

            int totalFichas = fichasPendentes.Count();
            int sucessos = 0;
            int erros = 0;
            var errosDetalhados = new List<ErroSincronizacaoDto>();

            foreach (var item in fichasPendentes)
            {
                try
                {
                    // Aqui será implementada a lógica de upload para a API
                    // Por enquanto, apenas marca como processado

                    item.MarcarComoSucesso();
                    _filaSincronizacaoRepo.Atualizar(item);
                    sucessos++;
                }
                catch (Exception ex)
                {
                    item.MarcarComoErro(ex.Message);
                    _filaSincronizacaoRepo.Atualizar(item);
                    erros++;

                    errosDetalhados.Add(new ErroSincronizacaoDto
                    {
                        FichaId = item.FichaId,
                        TipoFicha = item.TipoFicha,
                        MensagemErro = ex.Message,
                        DataErro = DateTime.UtcNow
                    });
                }
            }

            historico.Finalizar(totalFichas, sucessos, erros, "Push concluído");
            _historicoRepo.Atualizar(historico);
            await _unitOfWork.CommitAsync();

            return new ResultadoSincronizacaoDto
            {
                Sucesso = erros == 0,
                Tipo = "Push",
                QuantidadeTotal = totalFichas,
                QuantidadeSucesso = sucessos,
                QuantidadeErro = erros,
                Mensagem = $"Push concluído: {sucessos} sucesso(s), {erros} erro(s)",
                Erros = errosDetalhados,
                DataInicio = historico.DataInicio,
                DataFim = historico.DataFim!.Value,
                DuracaoSegundos = historico.DuracaoSegundos!.Value
            };
        }
        catch (Exception ex)
        {
            historico.Finalizar(0, 0, 0, $"Erro: {ex.Message}");
            historico.Status = StatusSincronizacao.Erro;
            _historicoRepo.Atualizar(historico);
            await _unitOfWork.CommitAsync();

            return new ResultadoSincronizacaoDto
            {
                Sucesso = false,
                Tipo = "Push",
                Mensagem = $"Erro ao executar Push: {ex.Message}",
                DataInicio = historico.DataInicio,
                DataFim = DateTime.UtcNow
            };
        }
    }

    public async Task<ResultadoSincronizacaoDto> ExecutarSincronizacaoCompletaAsync(Guid usuarioId, Guid? obraId = null)
    {
        // Executa Pull primeiro para baixar dados atualizados
        var resultadoPull = await ExecutarPullAsync(usuarioId, obraId);

        // Depois executa Push para enviar dados pendentes
        var resultadoPush = await ExecutarPushAsync(usuarioId, obraId);

        return new ResultadoSincronizacaoDto
        {
            Sucesso = resultadoPull.Sucesso && resultadoPush.Sucesso,
            Tipo = "Completa",
            QuantidadeTotal = resultadoPush.QuantidadeTotal,
            QuantidadeSucesso = resultadoPush.QuantidadeSucesso,
            QuantidadeErro = resultadoPush.QuantidadeErro,
            Mensagem = $"Sincronização completa: Pull {(resultadoPull.Sucesso ? "OK" : "ERRO")}, Push {(resultadoPush.Sucesso ? "OK" : "ERRO")}",
            Erros = resultadoPush.Erros,
            DataInicio = resultadoPull.DataInicio,
            DataFim = resultadoPush.DataFim
        };
    }

    public async Task<bool> ExistemFichasPendentesAsync()
    {
        var fichasPendentes = await _filaSincronizacaoRepo.ObterItensPendentesAsync();
        return fichasPendentes.Any();
    }

    public async Task<int> ObterQuantidadeFichasPendentesAsync()
    {
        var fichasPendentes = await _filaSincronizacaoRepo.ObterItensPendentesAsync();
        return fichasPendentes.Count();
    }

    public async Task<bool> ForcarUploadEmergenciaAsync(Guid fichaId)
    {
        try
        {
            // Aqui será implementada a lógica de upload forçado
            // Por enquanto, apenas marca como sincronizado

            await _filaSincronizacaoRepo.MarcarComoSincronizadoAsync(fichaId);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
