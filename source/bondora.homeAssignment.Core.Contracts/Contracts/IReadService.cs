using System.Collections.Generic;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Core.Services.Contracts
{
    public interface IReadService<T>
    {
        Task<T> Get(long id);
        Task<IEnumerable<T>> List();
    }
}