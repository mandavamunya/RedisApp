using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedisApp.DistributedCache.Application.Services;
using RedisApp.DistributedCache.Domain.Entities;

namespace RedisApp.DistributedCache.Api.Controllers
{
    public class CacheDataController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        public CacheDataController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet("GetCacheData/{key}")]
        public async Task<IActionResult> GetData([FromRoute] string key)
        {
            var users = (await _cacheService.GetFromCache(key));
            return Ok(users);
        }

        [HttpPost("SetCacheData")]
        public async Task<IActionResult> GetData([FromBody] User user)
        {
            await _cacheService.SetCache(user);
            return Ok();
        }
    }
}
