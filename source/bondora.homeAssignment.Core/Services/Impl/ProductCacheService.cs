using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models.Contracts.Product;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Core.Services.Impl
{
    public class ProductCacheService : IProductCacheService
    {
        private readonly ICacheService cacheService;
        private readonly ILogger<ProductCacheService> logger;

        public ProductCacheService(ICacheService cacheService, ILogger<ProductCacheService> logger)
        {
            this.cacheService = cacheService;
            this.logger = logger;
        }

        public async Task SetProducts(IEnumerable<ProductContract> products)
        {
            this.logger.LogDebug("Caching products");
            await this.cacheService.Set(this.GetProductsCacheKey(), products).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ProductContract>> GetProducts()
        {
            var ret = await this.cacheService.Get<IEnumerable<ProductContract>>(this.GetProductsCacheKey()).ConfigureAwait(false);
            if (ret == null)
            {
                this.logger.LogDebug("Cache miss for products");
            }
            return ret;
        }
        public async Task ResetProducts() => await this.cacheService.Remove(this.GetProductsCacheKey()).ConfigureAwait(false);

        public async Task SetProduct(ProductContract product)
        {
            this.logger.LogDebug($"Caching product #{product?.Id}");
            await this.cacheService.Set(this.GetProductCacheKey(product?.Id), product).ConfigureAwait(false);
        }

        public async Task<ProductContract> GetProduct(long id)
        {
            var ret = await this.cacheService.Get<ProductContract>(this.GetProductCacheKey(id)).ConfigureAwait(false);
            if (ret == null)
            {
                this.logger.LogDebug($"Cache miss for product #{id}");
            }
            return ret;
        }

        private string GetProductsCacheKey() => "proudcts";
        private string GetProductCacheKey(long? id) => $"products_{id}";
    }
}
