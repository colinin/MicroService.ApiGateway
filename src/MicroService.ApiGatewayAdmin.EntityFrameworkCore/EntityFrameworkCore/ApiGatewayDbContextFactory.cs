using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MicroService.ApiGateway.EntityFrameworkCore
{
    public class ApiGatewayDbContextFactory : IDesignTimeDbContextFactory<ApiGatewayDbContext>
    {
        public ApiGatewayDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ApiGatewayDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new ApiGatewayDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MicroService.ApiGatewayAdmin.Web/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
