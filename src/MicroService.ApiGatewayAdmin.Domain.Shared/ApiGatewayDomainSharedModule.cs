using MicroService.ApiGateway.Localization.MicroService.ApiGateway;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace MicroService.ApiGatewayAdmin.Domain.Shared
{
    [DependsOn(typeof(AbpLocalizationModule))]
    public class ApiGatewayDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<ApiGatewayResource>("zh-Hans");
            });
        }
    }
}
