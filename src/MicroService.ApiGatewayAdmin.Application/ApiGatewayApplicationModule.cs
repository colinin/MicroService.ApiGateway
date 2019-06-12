using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Localization;
using MicroService.ApiGatewayAdmin.Domain.Localization.ApiGateway;

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
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ApiGatewayApplicationModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ApiGatewayResource>()
                    .AddVirtualJson("/MicroService/ApiGatewayAdmin/Application/Localization/ApiGateway");
            });

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
