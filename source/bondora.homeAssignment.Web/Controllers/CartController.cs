using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models.DTO.CartItem;

namespace bondora.homeAssignment.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        // GET: Cart
        public async Task<IActionResult> Index(int page = 1) => this.View(await this.cartService.List(page));

        // POST: Cart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var model = await this.cartService.Get(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await this.cartService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
