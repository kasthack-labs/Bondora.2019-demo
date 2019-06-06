using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bondora.homeAssignment.Data;
using AutoMapper;
using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models.DTO;
using AutoMapper.QueryableExtensions;
using bondora.homeAssignment.Models.DTO.CartItem;
using System;

namespace bondora.homeAssignment.Core.Services.Impl
{
    public class CartService : ICartService
    {
        private readonly DemoAppContext context;
        private readonly IConfigurationProvider mapperConfiguration;
        private readonly IMapper mapper;
        private readonly IUserIdProvider userIdProvider;

        public CartService(DemoAppContext context, IConfigurationProvider mapperConfiguration, IMapper mapper, IUserIdProvider userIdProvider)
        {
            this.context = context;
            this.mapperConfiguration = mapperConfiguration;
            this.mapper = mapper;
            this.userIdProvider = userIdProvider;
        }

        public async Task<CartItemContract> Get(long id)
        {
            var item = await this.context.CartItems.Where(a => a.Id == id).ProjectTo<CartItemContract>(this.mapperConfiguration).FirstOrDefaultAsync();
            //if (await this.userIdProvider.GetUserId() != item.UserId) throw new UnauthorizedAccessException();
            return item;
        }
        public async Task<IEnumerable<CartItemContract>> List(int page = 1)
        {
            var userId = await this.userIdProvider.GetUserId();
            return await this.context
                .CartItems
                .Where(a => a.UserId == userId)
                .Skip((page - 1) * 10)
                .Take(10).ProjectTo<CartItemContract>(this.mapperConfiguration)
                .ToArrayAsync();
        }

        public async Task<long> Delete(long id)
        {
            var item = await this.context.CartItems.FirstOrDefaultAsync(a => a.Id == id);
            if (item == null) return id;
            item.Deleted = true;
            await this.context.SaveChangesAsync();
            return id;
        }

        public async Task<CartItemContract> Create(CreateCartItemContract contract)
        {
            var item = this.mapper.Map<CartItem>(contract);
            item.UserId = await this.userIdProvider.GetUserId();
            this.context.CartItems.Add(item);
            await this.context.SaveChangesAsync();
            return await this.Get(item.Id);
        }
        public async Task<CartItemContract> Update(UpdateCartItemContract contract)
        {
            var item = await this.context.CartItems.FirstOrDefaultAsync(a => a.Id == contract.Id);
            if (item == null) throw null;
            if (await this.userIdProvider.GetUserId() != item.UserId) throw new UnauthorizedAccessException();
            this.mapper.Map(contract, item);
            await this.context.SaveChangesAsync();
            return await this.Get(contract.Id);
        }
    }
}
