using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Api
{
    [Route("api/[controller]/[action]")]

    public class ProductController
    {
        private readonly IProductsService productsService;

        public ProductController(IProductsService productsService) => this.productsService = productsService;

        [HttpGet]
        public async Task<IEnumerable<ProductContract>> GetProducts() => await this.productsService.List().ConfigureAwait(false);

        [HttpGet]
        public async Task<ProductContract> GetProduct(long id) => await this.productsService.Get(id).ConfigureAwait(false);
    }
}
