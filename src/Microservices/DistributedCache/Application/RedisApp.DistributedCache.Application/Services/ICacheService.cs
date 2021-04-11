using System.Threading.Tasks;
using RedisApp.DistributedCache.Domain.Entities;

namespace RedisApp.DistributedCache.Application.Services
{
    public interface ICacheService
    {
        Task<User> GetFromCache(string key);
        Task SetCache(User user);
    }
}
