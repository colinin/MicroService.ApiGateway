using MicroService.ApiGateway.Settings;
using MicroService.ApiGatewayAdmin.Domain.Localization.ApiGateway;
using MicroService.ApiGatewayAdmin.Domain.Shared;
using Volo.Abp.Auditing;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;
using Volo.Abp.VirtualFileSystem;

namespace MicroService.ApiGateway
{
    /// <remarks>
    /// <see cref="AbpMicroServiceJsonModule"/> 为本地微服务
    /// 公共Json序列化模块,因作者某些内部敏感代码原因不传入GitHub
    /// <see cref="Volo.Abp.MicroService.Json.Newtonsoft.AbpHexLongConverter"/>
    /// 转换器也属于此模块,可以去掉对它的依赖
    /// </remarks>
    [DependsOn(
        typeof(ApiGatewayDomainSharedModule),
        typeof(AbpLocalizationModule),
        typeof(AbpAuditingModule)
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
                    .AddVirtualJson("/MicroService/ApiGatewayAdmin/Domain/Localization/ApiGateway");
            });

            Configure<SettingOptions>(options =>
            {
                options.DefinitionProviders.Add<ApiGatewaySettingDefinitionProvider>();
            });
        }
    }
}
