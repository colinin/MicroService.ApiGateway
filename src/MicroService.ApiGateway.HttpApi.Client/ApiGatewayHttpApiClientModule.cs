using MicroService.ApiGatewayAdmin.Application.Shared;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace MicroService.ApiGateway.HttpApi.Client
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(ApiGatewayApplicationSharedModule)
        )]
    public class ApiGatewayHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "ApiGateway";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ApiGatewayApplicationSharedModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
