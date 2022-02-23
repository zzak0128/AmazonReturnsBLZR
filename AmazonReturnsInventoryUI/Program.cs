using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AmazonReturnsInventoryUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseUrls("https://192.168.1.18:5001");
                });
    }
}
