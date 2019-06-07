using bondora.homeAssignment.Core.Services.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Core.Services.Impl
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache distrubutedCache;
        private readonly ILogger<CacheService> logger;

        public CacheService(IDistributedCache distrubutedCache, ILogger<CacheService> logger)
        {
            this.distrubutedCache = distrubutedCache;
            this.logger = logger;
        }

        public async Task Set(string key, object value, TimeSpan? duration) => await this.distrubutedCache.SetStringAsync(
            key,
            JsonConvert.SerializeObject(value),
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = duration
            }).ConfigureAwait(false);

        public async Task Remove(string key) => await this.distrubutedCache.RemoveAsync(key).ConfigureAwait(false);

        public async Task<T> Get<T>(string key)
        {
            var value = await this.distrubutedCache.GetStringAsync(key).ConfigureAwait(false);
            if (value == null)
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
