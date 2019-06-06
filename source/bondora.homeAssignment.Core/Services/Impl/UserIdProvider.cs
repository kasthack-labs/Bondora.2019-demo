using bondora.homeAssignment.Core.Services.Contracts;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Core.Services.Impl
{

    public class MockUserIdProvider : IUserIdProvider
    {
        public async Task<long> GetUserId() => 1;
    }
}
