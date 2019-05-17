using Volo.Abp;

namespace MicroService.ApiGateway
{
    public abstract class ApiGatewayApplicationTestBase : AbpIntegratedTest<ApiGatewayApplicationTestModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
