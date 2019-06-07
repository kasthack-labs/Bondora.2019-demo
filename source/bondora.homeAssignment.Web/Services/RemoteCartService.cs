using System.Collections.Generic;
using System.Threading.Tasks;
using bondora.homeAssignment.ApiClient.Api;
using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models.Contracts.Cart;
using bondora.homeAssignment.Models.Contracts.Product;

namespace bondora.homeAssignment.Web.Services
{
    public class RemoteCartService : ICartService
    {
        private readonly IUserCartApi apiClient;

        public RemoteCartService(IUserCartApi apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<CartItemContract> Create(CreateCartItemContract contract) => await this.apiClient.ApiUserCartCreatePostAsync(contract.ProductId, contract.Duration);
        public async Task<long> Delete(long id) => await this.apiClient.ApiUserCartDeletePostAsync(id);
        public async Task<CartItemContract> Get(long id) => await this.apiClient.ApiUserCartGetGetAsync(id);
        public async Task<IEnumerable<CartItemContract>> List() => await this.apiClient.ApiUserCartListGetAsync();
        public async Task<CartItemContract> Update(UpdateCartItemContract contract) => await this.apiClient.ApiUserCartUpdatePostAsync(contract.Id, contract.Duration)
    }
}
