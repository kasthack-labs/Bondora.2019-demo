using System.Reflection;
using bondora.homeAssignment.ApiClient.Api;
using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace bondora.homeAssignment.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options => options.CheckConsentNeeded = context => true);
            var apiRoot = "http://localhost:31337/";
            services
                .AddSingleton<IInvoiceApi>(cfg => new InvoiceApi(apiRoot))
                .AddSingleton<IUserCartApi>(cfg => new UserCartApi(apiRoot))
                .AddSingleton<IProductApi>(cfg => new ProductApi(apiRoot))

                .AddSingleton<IProductsService, RemoteProductsService>()
                .AddSingleton<ICartService, RemoteCartService>()
                .AddSingleton<IInvoiceService, RemoteInvoiceService>()
                ;

            services
                .AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Equimpent rental API V1", Version = "v1" }));

            services
                .AddMvc()
                .AddApplicationPart(Assembly.Load("bondora.homeAssignment.Api"))
                .AddControllersAsServices()
                .AddNewtonsoftJson();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app
                    .UseExceptionHandler("/Home/Error")
                    .UseHsts();
            }

            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseCookiePolicy()
                .UseRouting()
                .UseAuthorization()
                .UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Equimpent rental API V1"))
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Products}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });
        }
    }
}
