using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models.Contracts.Cart;

namespace bondora.homeAssignment.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService) => this.cartService = cartService;

        public async Task<IActionResult> Index() => this.View(await this.cartService.List().ConfigureAwait(false));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCartItemContract contract)
        {
            if (this.ModelState.IsValid)
            {
                await this.cartService.Create(contract).ConfigureAwait(false);
            }
            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, UpdateCartItemContract cartItem)
        {
            if (id != cartItem.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                await this.cartService.Update(cartItem).ConfigureAwait(false);
                return this.RedirectToAction(nameof(Index));
            }
            return this.View(cartItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id)
        {
            await this.cartService.Delete(id).ConfigureAwait(false);
            return this.RedirectToAction(nameof(Index));
        }
    }
}
