using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MicroService.ApiGateway.EntityFrameworkCore
{
    public class ApiGatewayMigrationsDbContextFactory : IDesignTimeDbContextFactory<ApiGatewayMigrationsDbContext>
    {
        public ApiGatewayMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ApiGatewayMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));

            return new ApiGatewayMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MicroService.ApiGatewayAdmin.Web/"))
                .AddJsonFile("appsettings.Development.json", optional: false);

            return builder.Build();
        }
    }
}
