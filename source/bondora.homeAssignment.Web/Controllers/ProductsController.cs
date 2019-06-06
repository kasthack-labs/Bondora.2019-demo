using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bondora.homeAssignment.Core.Services.Contracts;

namespace bondora.homeAssignment.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService) => this.productsService = productsService;

        public async Task<IActionResult> Index(int? page = null) => this.View(await this.productsService.List((int)(page ?? 1)));

        public async Task<IActionResult> Details(long id)
        {
            var product = await this.productsService.Get(id);
            if (product == null)
            {
                return this.NotFound();
            }
            return this.View(product);
        }
    }
}
