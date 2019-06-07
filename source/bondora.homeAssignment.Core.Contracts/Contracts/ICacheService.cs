using System;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Core.Services.Contracts
{
    public interface ICacheService
    {
        Task<T> Get<T>(string key);
        Task Remove(string key);
        Task Set(string key, object value, TimeSpan? duration = null);
    }
}