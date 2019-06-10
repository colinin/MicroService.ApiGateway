using MicroService.ApiGateway.Localization.MicroService.ApiGateway;
using MicroService.ApiGatewayAdmin.Domain.Shared;
using Volo.Abp.Application;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace MicroService.ApiGatewayAdmin.Application.Shared
{
    [DependsOn(typeof(ApiGatewayDomainSharedModule), typeof(AbpDddApplicationModule))]
    public class ApiGatewayApplicationSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ApiGatewayApplicationSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ApiGatewayResource>()
                    .AddVirtualJson("/Localization/ApiGateway");
            });
        }
    }
}
