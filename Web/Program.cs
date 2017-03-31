using Cmas.Infrastructure.ServicesStartup;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                //.UseIISIntegration()
                .UseStartup<ServicesStartup>()
                .Build();

            host.Run();
        }
    }
}