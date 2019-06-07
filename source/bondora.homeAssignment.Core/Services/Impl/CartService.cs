using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bondora.homeAssignment.Data;
using AutoMapper;
using bondora.homeAssignment.Core.Services.Contracts;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Logging;
using bondora.homeAssignment.Models.Contracts.Cart;
using System;

namespace bondora.homeAssignment.Core.Services.Impl
{
    public class CartService : ICartService
    {
        private readonly Func<DemoAppContext> contextFactory;
        private readonly ILogger<CartService> logger;
        private readonly IPriceService priceService;
        private readonly IConfigurationProvider mapperConfiguration;
        private readonly IMapper mapper;

        public CartService(Func<DemoAppContext> contextFactory, IPriceService priceService, ILogger<CartService> logger, IConfigurationProvider mapperConfiguration, IMapper mapper)
        {
            this.contextFactory = contextFactory;
            this.priceService = priceService;
            this.logger = logger;
            this.mapperConfiguration = mapperConfiguration;
            this.mapper = mapper;
        }

        public async Task<CartItemContract> Get(long id)
        {
            using (var context = this.contextFactory())
            {
                var item = await context.CartItems.Where(a => a.Id == id).ProjectTo<CartItemContract>(this.mapperConfiguration).FirstOrDefaultAsync();
                await this.SetPrices(item);
                return item;
            }
        }

        public async Task<IEnumerable<CartItemContract>> List()
        {
            using (var context = this.contextFactory())
            {
                var items = await context
                    .CartItems
                    .ProjectTo<CartItemContract>(this.mapperConfiguration)
                    .ToArrayAsync();

                await this.SetPrices(items);

                return items;
            }
        }

        public async Task<long> Delete(long id)
        {

            using (var context = this.contextFactory())
            {
                var item = await context.CartItems.FirstOrDefaultAsync(a => a.Id == id);
                if (item == null) return id;
                item.Deleted = true;
                await context.SaveChangesAsync();
                this.logger.LogDebug($"Deleted item #{item.Id} from cart");
                return id;
            }
        }

        public async Task<CartItemContract> Create(CreateCartItemContract contract)
        {

            using (var context = this.contextFactory())
            {
                var item = this.mapper.Map<CartItem>(contract);
                context.CartItems.Add(item);
                await context.SaveChangesAsync();
                this.logger.LogDebug($"Added item #{item.Id} to cart");
                return await this.Get(item.Id);
            }
        }

        public async Task<CartItemContract> Update(UpdateCartItemContract contract)
        {

            using (var context = this.contextFactory())
            {
                var item = await context.CartItems.FirstOrDefaultAsync(a => a.Id == contract.Id);
                if (item == null) throw null;
                this.mapper.Map(contract, item);
                await context.SaveChangesAsync();
                this.logger.LogDebug($"Upated cart item #{item.Id}: changed {nameof(contract.Duration)} to {contract.Duration}");
                return await this.Get(contract.Id);
            }
        }
        
        //todo: move to a separate service
        private async Task SetPrices(params CartItemContract[] cart)
        {
            var variables = await this.priceService.GetPrices();
            var engine = new Jace.CalculationEngine();

            foreach (var cartItem in cart)
            {
                variables["duration"] = cartItem.Duration;

                var category = cartItem.Product.Category;
                var priceFormula = engine.Build(category.PricingFormula);
                cartItem.Price = (decimal)priceFormula(variables);

                var loyaltyFormula = engine.Build(category.LoyaltyFormula);
                cartItem.LoyaltyPoints = (int)loyaltyFormula(variables);
            }
        }
    }
}
