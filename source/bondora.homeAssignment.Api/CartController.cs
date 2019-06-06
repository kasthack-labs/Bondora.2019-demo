using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models.DTO;
using bondora.homeAssignment.Models.DTO.CartItem;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Api
{
    [Route("api/[controller]/[action]")]

    public class CartController
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService) => this.cartService = cartService;

        [HttpPost]
        public Task<CartItemContract> Create(CreateCartItemContract contract) => this.cartService.Create(contract);
        [HttpPost]
        public Task<long> Delete(long id) => this.cartService.Delete(id);

        [HttpPost]
        public Task<CartItemContract> Update(UpdateCartItemContract contract) => this.cartService.Update(contract);
        [HttpGet]
        public Task<CartItemContract> Get(long id) => this.cartService.Get(id);
        [HttpGet]
        public Task<IEnumerable<CartItemContract>> List(int page = 1) => this.cartService.List(page);
    }
}
