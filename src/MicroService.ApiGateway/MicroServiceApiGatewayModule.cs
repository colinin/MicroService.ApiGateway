using MicroService.ApiGateway.HttpApi.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Configuration.Repository;
using Ocelot.DependencyInjection;
using Ocelot.Extenssions;
using Ocelot.Provider.Polly;
using Serilog;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace MicroService.ApiGateway
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpHttpClientIdentityModelModule),
        typeof(AbpAutoMapperModule),
        typeof(ApiGatewayHttpApiClientModule),
        typeof(AbpAspNetCoreModule)
        )]
    public class MicroServiceApiGatewayModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(configuration)
               .CreateLogger();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MicroServiceApiGatewayMapperProfile>();
            });

            // 不启用则使用本地配置文件的方式启动Ocelot
            if (configuration.GetValue<bool>("EnabledDynamicOcelot"))
            {
                context.Services.AddSingleton<IFileConfigurationRepository, ApiHttpClientFileConfigurationRepository>();
                ConfigureCAP(context.Services, configuration);
            }

            context.Services
                .AddOcelot()
                .AddPolly();
        }

        private void ConfigureCAP(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddCap(x =>
            {
                x.UseInMemoryStorage();

                x.UseDashboard();

                x.UseRabbitMQ(cfg =>
                {
                    cfg.HostName = configuration.GetValue<string>("CAP:RabbitMQ:Connect:Host");
                    cfg.VirtualHost = configuration.GetValue<string>("CAP:RabbitMQ:Connect:VirtualHost");
                    cfg.Port = configuration.GetValue<int>("CAP:RabbitMQ:Connect:Port");
                    cfg.UserName = configuration.GetValue<string>("CAP:RabbitMQ:Connect:UserName");
                    cfg.Password = configuration.GetValue<string>("CAP:RabbitMQ:Connect:Password");
                    cfg.ExchangeName = configuration.GetValue<string>("CAP:RabbitMQ:Connect:ExchangeName");
                });

                x.FailedRetryCount = 5;
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            app.UseAuditing();

            app.UseOcelot().Wait();
        }
    }
}
