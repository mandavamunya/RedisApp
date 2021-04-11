using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace RedisApp.DistributedCache.Data.Context
{
    public class CacheProvider<T> : ICacheProvider<T>
    {
        private readonly IDistributedCache _cache;

        public CacheProvider(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetFromCache(string key)
        {
            var cachedObject = await _cache.GetStringAsync(key);
            return cachedObject == null ? default : JsonSerializer.Deserialize<T>(cachedObject);
        }

        public async Task SetCache(string key, T value, DistributedCacheEntryOptions options)
        {
            var cacheObject = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, cacheObject, options);
        }

        public async Task ClearCache(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}
