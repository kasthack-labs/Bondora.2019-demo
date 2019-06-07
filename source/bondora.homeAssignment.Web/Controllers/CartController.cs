using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models.Contracts.Cart;

namespace bondora.homeAssignment.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public async Task<IActionResult> Index(int page = 1) => this.View(await this.cartService.List());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCartItemContract contract)
        {
            if (this.ModelState.IsValid)
            {
                await this.cartService.Create(contract);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, UpdateCartItemContract cartItem)
        {
            if (id != cartItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await this.cartService.Update(cartItem);
                return RedirectToAction(nameof(Index));
            }
            return View(cartItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id)
        {
            await this.cartService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
