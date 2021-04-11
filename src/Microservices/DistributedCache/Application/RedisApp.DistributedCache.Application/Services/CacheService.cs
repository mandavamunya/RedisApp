using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using RedisApp.DistributedCache.Data.Context;
using RedisApp.DistributedCache.Domain.Entities;

namespace RedisApp.DistributedCache.Application.Services
{
    public class CacheService: ICacheService
    {
        private readonly ICacheProvider<User> _cacheProvider;
        public CacheService(ICacheProvider<User> cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        public async Task<User> GetFromCache(string key)
        {
            return await _cacheProvider.GetFromCache(key);
        }

        public async Task SetCache(User user)
        {
            var options = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(DateTimeOffset.Now.AddDays(1)) // indicates whether a cache entry should be evicted at a specified point in time.
            .SetSlidingExpiration(TimeSpan.FromDays(0.5));
            await _cacheProvider.SetCache(user.UserId.ToString(), user, options);
        }
    }
}
