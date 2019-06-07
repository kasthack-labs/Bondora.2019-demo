using AutoMapper;
using bondora.homeAssignment.Core;
using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Core.Services.Impl;
using bondora.homeAssignment.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Service
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var apiBuilder = CreateHostBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder
                    .UseStartup<Startup>()
                    .ConfigureKestrel(opts => opts.ListenAnyIP(31337)))
                .Build();
            var serviceBuilder = CreateHostBuilder(args).ConfigureServices(services => services.AddHostedService<Worker>());
            await Task.WhenAll(
                apiBuilder.RunAsync(),
                serviceBuilder.RunConsoleAsync()
            ).ConfigureAwait(false);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
                .CreateDefaultBuilder(args)
                .ConfigureServices(services => InjectServices(services))
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.SetMinimumLevel(LogLevel.Trace);
                    logging.AddConsole();
                    logging.AddDebug();
                });

        private static void InjectServices(IServiceCollection services) => services
                                .AddTransient<DemoAppContext>()
                                .AddSingleton<Func<DemoAppContext>>(x => () => x.GetRequiredService<DemoAppContext>())
                                .AddSingleton<IProductsService, ProductsService>()
                                .AddSingleton<ICartService, CartService>()
                                .AddSingleton<IPriceService, PriceService>()
                                .AddSingleton<IInvoiceService, InvoiceService>()
                                .AddSingleton<ICacheService, CacheService>()
                                .AddSingleton<IProductCacheService, ProductCacheService>()
                                .AddDistributedMemoryCache()
                                .AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()))

                                ;
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) => services
            .AddMvc()
            .AddApplicationPart(Assembly.Load("bondora.homeAssignment.Api"))
            .AddControllersAsServices();

        public void Configure(IApplicationBuilder app) => app.UseStaticFiles().UseRouting();
    }
}
