using MicroService.ApiGateway.Data.Filter;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace MicroService.ApiGateway.EntityFrameworkCore
{
    [DependsOn(
        typeof(ApiGatewayDomainModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule)
        )]
    public class ApiGatewayEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<DataFilterOptions>(options =>
            {
                options.DefaultStates.Add(typeof(IActivation), new DataFilterState(true));
            });

            context.Services.AddAbpDbContext<ApiGatewayDbContext>(options =>
            {
                //Remove "includeAllEntities: true" to create default repositories only for aggregate roots
                options.AddDefaultRepositories(includeAllEntities: true);
            });
        }
    }
}
