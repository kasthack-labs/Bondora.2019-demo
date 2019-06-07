using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Core.Services.Impl
{

    public class PriceService : IPriceService
    {
        private readonly Func<DemoAppContext> contextFactory;

        public PriceService(Func<DemoAppContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public async Task<Dictionary<string, double>> GetPrices()
        {
            using (var context = this.contextFactory())
            {
                return (await context.Prices.ToArrayAsync()).ToDictionary(a => a.Name, a => (double)a.Value);
            }
        }
    }
}
