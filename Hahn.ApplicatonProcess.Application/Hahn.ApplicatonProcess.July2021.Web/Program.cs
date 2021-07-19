using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Hahn.ApplicatonProcess.July2021.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
             CreateHostBuilder(args).Build().Run();
        }
        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureLogging(logging => {
                    logging.AddFilter("Microsoft", LogLevel.Information);
                    logging.AddFilter("System", LogLevel.Error);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
