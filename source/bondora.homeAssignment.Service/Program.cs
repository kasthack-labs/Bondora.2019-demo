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

namespace bondora.homeAssignment.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .ConfigureServices(services =>
                {
                    services
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
                    services.AddHostedService<Worker>();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConsole();
                    logging.AddDebug();
                });
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
