using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bondora.homeAssignment.Data;
using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using bondora.homeAssignment.Models.DTO;

namespace bondora.homeAssignment.Core.Services.Impl
{
    public class ProductsService : IProductsService
    {
        private readonly DemoAppContext context;
        private readonly IConfigurationProvider configurationProvider;

        public ProductsService(DemoAppContext context, IConfigurationProvider configurationProvider)
        {
            this.context = context;
            this.configurationProvider = configurationProvider;
        }

        public async Task<ProductContract> Get(long id)
        {
            var product = await this.context.Products
                .Where(m => m.Id == id)
                .ProjectTo<ProductContract>(this.configurationProvider)
                .FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<ProductContract>> List(int page)
        {
            var pageSize = 10;
            var products = await this.context
                .Products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<ProductContract>(this.configurationProvider)
                .ToListAsync();
            return products;
        }
    }
}
