using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.InProcess;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace MicroService.ApiGateway
{
    public class Program
    {
        public static int Main(string[] args)
        {
            CurrentDirectoryHelpers.SetCurrentDirectory();
            try
            {
                Log.Information("Starting web host.");
                BuildWebHostInternal(args).Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHostInternal(string[] args) =>
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();
    }
}
