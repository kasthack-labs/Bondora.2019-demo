using AutoMapper;
using bondora.homeAssignment.Core;
using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Core.Services.Impl;
using bondora.homeAssignment.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace bondora.homeAssignment.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {

                    services
                        .AddTransient<DemoAppContext>()
                        .AddSingleton<Func<DemoAppContext>>(x => () => x.GetRequiredService<DemoAppContext>())
                        .AddTransient<IProductsService, ProductsService>()
                        .AddTransient<ICartService, CartService>()
                        .AddTransient<IPriceService, PriceService>()
                        .AddTransient<IInvoiceService, InvoiceService>()
                        .AddTransient<ICacheService, CacheService>()
                        .AddTransient<IProductCacheService, ProductCacheService>()
                        .AddDistributedMemoryCache()
                        .AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()))
                        ;
                    services.AddHostedService<Worker>();
                });
    }
}
