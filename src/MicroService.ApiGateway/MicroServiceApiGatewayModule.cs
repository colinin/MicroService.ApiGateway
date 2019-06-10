using MicroService.ApiGateway.HttpApi.Client;
using MicroService.ApiGateway.Ocelot;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ocelot.Configuration.Repository;
using Ocelot.DependencyInjection;
using Ocelot.Extenssions;
using Ocelot.Provider.Polly;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace MicroService.ApiGateway
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpHttpClientIdentityModelModule),
        typeof(ApiGatewayHttpApiClientModule),
        typeof(AbpAspNetCoreModule)
        )]
    public class MicroServiceApiGatewayModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();



            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MicroServiceApiGatewayMapperProfile>();
            });

            context.Services.AddTransient<IFileConfigurationRepository, EfCoreFileConfigurationRepository>();

            context.Services.AddOcelot().AddPolly();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            app.UseOcelot().Wait();
        }
    }
}
