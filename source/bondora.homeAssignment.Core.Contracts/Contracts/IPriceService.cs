using System.Collections.Generic;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Core.Services.Contracts
{
    public interface IPriceService
    {
        Task<Dictionary<string, double>> GetPrices();
    }
}
