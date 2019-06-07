using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bondora.homeAssignment.Data;
using bondora.homeAssignment.Core.Services.Contracts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using bondora.homeAssignment.Models.Contracts.Product;
using System;

namespace bondora.homeAssignment.Core.Services.Impl
{
    public class ProductsService : IProductsService
    {
        private readonly Func<DemoAppContext> contextFactory;
        private readonly IConfigurationProvider configurationProvider;
        private readonly IProductCacheService cache;

        public ProductsService(Func<DemoAppContext> contextFactory, IProductCacheService cache, IConfigurationProvider configurationProvider)
        {
            this.contextFactory = contextFactory;
            this.configurationProvider = configurationProvider;
            this.cache = cache;
        }

        public async Task<ProductContract> Get(long id)
        {
            var product = await this.cache.GetProduct(id);
            if (product != null)
            {
                return product;
            }
            using (var context = this.contextFactory())
            {
                product = await context.Products
                .Where(m => m.Id == id)
                .ProjectTo<ProductContract>(this.configurationProvider)
                .FirstOrDefaultAsync();
            }
            await this.cache.SetProduct(product);

            return product;
        }

        public async Task<IEnumerable<ProductContract>> List()
        {
            var products = await this.cache.GetProducts();
            if (products != null)
            {
                return products;
            }

            using (var context = this.contextFactory())
            {
                products = await context
                .Products
                .ProjectTo<ProductContract>(this.configurationProvider)
                .ToListAsync();
            }
            await this.cache.SetProducts(products);

            return products;
        }
    }
}
