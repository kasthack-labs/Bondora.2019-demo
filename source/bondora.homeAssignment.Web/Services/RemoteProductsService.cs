using System.Collections.Generic;
using System.Threading.Tasks;
using bondora.homeAssignment.ApiClient.Api;
using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models.Contracts.Product;

namespace bondora.homeAssignment.Web.Services
{
    public class RemoteProductsService : IProductsService
    {
        private readonly IProductApi apiClient;

        public RemoteProductsService(IProductApi apiClient) => this.apiClient = apiClient;
        public async Task<ProductContract> Get(long id) => await this.apiClient.ApiProductGetProductGetAsync(id).ConfigureAwait(false);
        public async Task<IEnumerable<ProductContract>> List() => await this.apiClient.ApiProductGetProductsGetAsync().ConfigureAwait(false);
    }
}
