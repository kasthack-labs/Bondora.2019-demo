using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models.Contracts.Cart;

namespace bondora.homeAssignment.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService) => this.productsService = productsService;

        public async Task<IActionResult> Index() => this.View(await this.productsService.List().ConfigureAwait(false));

        public async Task<IActionResult> Details(long id)
        {
            var product = await this.productsService.Get(id).ConfigureAwait(false);
            if (product == null)
            {
                return this.NotFound();
            }
            //dirty hack for simple validation
            return this.View(new CartItemContract
            {
                Product = product,
                Duration = 7
            });
        }
    }
}
