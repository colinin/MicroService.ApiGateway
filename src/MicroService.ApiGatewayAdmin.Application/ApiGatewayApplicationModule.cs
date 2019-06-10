using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

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
                options.Configurators.Add(ctx =>
                {
                    var mapperProfile = ctx.ServiceProvider.GetService<ApiGatewayApplicationAutoMapperProfile>();
                    ctx.MapperConfiguration.AddProfile(mapperProfile);
                });
            });
        }
    }
}
