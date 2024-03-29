using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart
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
                });


        //WebHost.CreateDefaultBuilder(args)
        //    .ConfigureAppConfiguration((context, builder) => builder.SetBasePath(context.HostingEnvironment.ContentRootPath)
        //               .AddJsonFile("appsettings.json")
        //               .Build())

        //    .UseStartup<Startup>()
        //    .Build();
    }
}
