using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace MicroService.ApiGateway.EntityFrameworkCore
{
    public class ApiGatewayMigrationsDbContext : AbpDbContext<ApiGatewayMigrationsDbContext>
    {
        public ApiGatewayMigrationsDbContext(DbContextOptions<ApiGatewayMigrationsDbContext> options)
            : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureApiGateway();
            modelBuilder.ConfigureSettingManagement();
        }
    }
}
