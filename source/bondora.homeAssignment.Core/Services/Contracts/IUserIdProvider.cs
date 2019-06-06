using System.Threading.Tasks;

namespace bondora.homeAssignment.Core.Services.Contracts
{
    public interface IUserIdProvider
    {
        Task<long> GetUserId();
    }
}