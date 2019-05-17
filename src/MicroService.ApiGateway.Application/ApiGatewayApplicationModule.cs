using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace MicroService.ApiGateway
{
    [DependsOn(
        typeof(ApiGatewayDomainModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpDddApplicationModule)
        )]
    public class ApiGatewayApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ApiGatewayApplicationAutoMapperProfile>();
            });
        }
    }
}
