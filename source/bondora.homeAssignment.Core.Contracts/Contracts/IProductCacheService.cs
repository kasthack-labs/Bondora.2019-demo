using System.Collections.Generic;
using System.Threading.Tasks;
using bondora.homeAssignment.Models.Contracts.Product;

namespace bondora.homeAssignment.Core.Services.Contracts
{
    public interface IProductCacheService
    {
        Task<ProductContract> GetProduct(long id);
        Task<IEnumerable<ProductContract>> GetProducts();
        Task ResetProducts();
        Task SetProduct(ProductContract product);
        Task SetProducts(IEnumerable<ProductContract> products);
    }
}