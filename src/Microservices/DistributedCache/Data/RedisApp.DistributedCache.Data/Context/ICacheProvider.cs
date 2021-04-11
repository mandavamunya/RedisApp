using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace RedisApp.DistributedCache.Data.Context
{
    public interface ICacheProvider<T>
    {
        Task<T> GetFromCache(string key);
        Task SetCache(string key, T value, DistributedCacheEntryOptions options);
    }
}
