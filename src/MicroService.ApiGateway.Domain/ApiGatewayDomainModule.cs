using MicroService.ApiGateway.Localization.MicroService.ApiGateway;
using MicroService.ApiGateway.Settings;
using Volo.Abp.Auditing;
using Volo.Abp.Localization;
using Volo.Abp.Localization.Resources.AbpValidation;
using Volo.Abp.MicroService.Json;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;
using Volo.Abp.VirtualFileSystem;

namespace MicroService.ApiGateway
{
    [DependsOn(
        typeof(AbpAuditingModule),
        typeof(AbpMicroServiceJsonModule)
        )]
    public class ApiGatewayDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ApiGatewayDomainModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ApiGatewayResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/ApiGateway");
            });

            Configure<SettingOptions>(options =>
            {
                options.DefinitionProviders.Add<ApiGatewaySettingDefinitionProvider>();
            });
        }
    }
}
