using System;
using System.Threading;
using System.Threading.Tasks;
using bondora.homeAssignment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace bondora.homeAssignment.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly DemoAppContext context;

        public Worker(ILogger<Worker> logger, DemoAppContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.logger.LogInformation("Started background service");
            await this.context.Database.MigrateAsync();
            await Task.Delay(Timeout.Infinite, stoppingToken);
            this.logger.LogInformation("Cancellation requested");
        }
    }
}
