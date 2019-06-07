using System.Threading.Tasks;
using bondora.homeAssignment.Models.Contracts.Cart;

namespace bondora.homeAssignment.Core.Services.Contracts
{
    public interface ICartService : IReadService<CartItemContract>
    {
        Task<CartItemContract> Create(CreateCartItemContract contract);
        Task<long> Delete(long id);
        Task<CartItemContract> Update(UpdateCartItemContract contract);
    }
}
