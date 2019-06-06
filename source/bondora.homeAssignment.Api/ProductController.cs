using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models;
using bondora.homeAssignment.Models.DTO;
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
        public async Task<IEnumerable<ProductContract>> GetProducts(int page) => await this.productsService.List(page);

        [HttpGet]
        public async Task<ProductContract> GetProduct(long id) => await this.productsService.Get(id);
    }
}
