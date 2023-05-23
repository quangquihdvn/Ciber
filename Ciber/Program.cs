using Ciber.Configure.Log;
using Ciber.Infrastructure.EF;
using Ciber.Infrastructure.Extensions;
using Ciber.Infrastructure.Infrastructure.EF;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;

namespace Ciber
{
    public class Program
    {
        private static readonly string AppName = typeof(Program).Namespace;
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                //.WriteTo.Console()
                .WriteTo.File(
                $"Logs/log_{DateTime.Now.ToString("yyyyMMddhhmmss")}.txt",
                fileSizeLimitBytes: 1_000_000,
                rollOnFileSizeLimit: true,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1))
                .CreateLogger();
            var configuration = SerilogExtension.GetConfiguration();
            try
            {
                var host = BuildWebHost(args);
                host.MigrateDbContext<CiberDbContext>((context, services) =>
                {
                    var logger = (ILogger<CiberDbContextSeed>)services.GetService(typeof(ILogger<CiberDbContextSeed>));
                    new CiberDbContextSeed()
                        .SeedAsync(context, logger)
                        .Wait();
                });
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .Build();
    }
}
