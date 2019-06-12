using MicroService.ApiGatewayAdmin.Domain.Shared;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace MicroService.ApiGatewayAdmin.Application.Shared
{
    [DependsOn(typeof(ApiGatewayDomainSharedModule), typeof(AbpDddApplicationModule))]
    public class ApiGatewayApplicationSharedModule : AbpModule
    {

    }
}
