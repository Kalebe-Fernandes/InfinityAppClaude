using Microsoft.Extensions.Caching.Memory;
using Domain.Interfaces.Servicos;

namespace Aplication.Servicos.Cache;

/// <summary>
/// Implementação do serviço de cache em memória.
/// Utiliza IMemoryCache para armazenamento temporário de dados.
/// </summary>
public class ServicoCacheMemoria(IMemoryCache cache) : ICacheService
{
    private readonly IMemoryCache _cache = cache;
    private static readonly TimeSpan TempoExpiracaoPadrao = TimeSpan.FromHours(1);

    public T? Obter<T>(string chave) where T : class
    {
        return _cache.Get<T>(chave);
    }

    public void Adicionar<T>(string chave, T valor, TimeSpan? tempoExpiracao = null) where T : class
    {
        var opcoes = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = tempoExpiracao ?? TempoExpiracaoPadrao
        };

        _cache.Set(chave, valor, opcoes);
    }

    public void Remover(string chave)
    {
        _cache.Remove(chave);
    }

    public void LimparTudo()
    {
        if (_cache is MemoryCache memoryCache)
        {
            memoryCache.Compact(1.0);
        }
    }

    public bool Existe(string chave)
    {
        return _cache.TryGetValue(chave, out _);
    }
}
