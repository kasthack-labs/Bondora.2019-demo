using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace bondora.homeAssignment.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>().ConfigureKestrel(opts => opts.ListenAnyIP(31337)))
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConsole();
                    logging.AddDebug();
                });
    }
}
