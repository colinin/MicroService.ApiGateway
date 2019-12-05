using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Configuration;
using Ocelot.Configuration.Creator;
using Ocelot.Configuration.File;
using Ocelot.Configuration.Repository;
using Ocelot.Logging;
using Ocelot.Middleware;
using Ocelot.Middleware.Pipeline;
using Ocelot.Responses;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ocelot.Extenssions
{
    public static class OcelotMiddlewareExtensions
    {
        public static async Task<IApplicationBuilder> UseOcelot(this IApplicationBuilder builder)
        {
            await builder.UseOcelot(new OcelotPipelineConfiguration());
            return builder;
        }

        public static async Task<IApplicationBuilder> UseOcelot(this IApplicationBuilder builder, Action<OcelotPipelineConfiguration> pipelineConfiguration)
        {
            var config = new OcelotPipelineConfiguration();
            pipelineConfiguration?.Invoke(config);
            return await builder.UseOcelot(config);
        }

        public static async Task<IApplicationBuilder> UseOcelot(this IApplicationBuilder builder, OcelotPipelineConfiguration pipelineConfiguration)
        {
            var configuration = await CreateConfiguration(builder);

            ConfigureDiagnosticListener(builder);

            return CreateOcelotPipeline(builder, pipelineConfiguration);
        }

        public static Task<IApplicationBuilder> UseOcelot(this IApplicationBuilder app, Action<IOcelotPipelineBuilder, OcelotPipelineConfiguration> builderAction)
            => UseOcelot(app, builderAction, new OcelotPipelineConfiguration());

        public static async Task<IApplicationBuilder> UseOcelot(this IApplicationBuilder app, Action<IOcelotPipelineBuilder, OcelotPipelineConfiguration> builderAction, OcelotPipelineConfiguration configuration)
        {
            await CreateConfiguration(app);  // initConfiguration

            ConfigureDiagnosticListener(app);

            var ocelotPipelineBuilder = new OcelotPipelineBuilder(app.ApplicationServices);
            builderAction?.Invoke(ocelotPipelineBuilder, configuration ?? new OcelotPipelineConfiguration());

            var ocelotDelegate = ocelotPipelineBuilder.Build();
            app.Properties["analysis.NextMiddlewareName"] = "TransitionToOcelotMiddleware";

            app.Use(async (context, task) =>
            {
                var downstreamContext = new DownstreamContext(context);
                await ocelotDelegate.Invoke(downstreamContext);
            });

            return app;
        }

        private static IApplicationBuilder CreateOcelotPipeline(IApplicationBuilder builder, OcelotPipelineConfiguration pipelineConfiguration)
        {
            var pipelineBuilder = new OcelotPipelineBuilder(builder.ApplicationServices);

            pipelineBuilder.BuildOcelotPipeline(pipelineConfiguration);

            var firstDelegate = pipelineBuilder.Build();

            /*
            inject first delegate into first piece of asp.net middleware..maybe not like this
            then because we are updating the http context in ocelot it comes out correct for
            rest of asp.net..
            */

            builder.Properties["analysis.NextMiddlewareName"] = "TransitionToOcelotMiddleware";

            builder.Use(async (context, task) =>
            {
                var downstreamContext = new DownstreamContext(context);
                await firstDelegate.Invoke(downstreamContext);
            });

            return builder;
        }

        private static async Task<IInternalConfiguration> CreateConfiguration(IApplicationBuilder builder)
        {
            /* 因为ABP框架中,Abp.HttpClient这个模块里面
             * RemoteServiceOptions 是用的IOptionsSnapshot注入的,这里会出现一个异常
             * 每个RemoteService服务必须在一个请求范围内
             * 解决方案为重写DynamicHttpProxyInterceptor类,替换IOptions<RemoteServiceOptions>
             * 网关不需要实现网关后台服务地址的实时更新
            */
            var fileConfigRepo = builder.ApplicationServices.GetRequiredService<IFileConfigurationRepository>();
            var fileConfig = await fileConfigRepo.Get();
            var internalConfigCreator = builder.ApplicationServices.GetRequiredService<IInternalConfigurationCreator>();
            var internalConfig = await internalConfigCreator.Create(fileConfig.Data);
            if (internalConfig.IsError)
            {
                ThrowToStopOcelotStarting(internalConfig);
            }
            var internalConfigRepo = builder.ApplicationServices.GetService<IInternalConfigurationRepository>();
            internalConfigRepo.AddOrReplace(internalConfig.Data);

            var configurations = builder.ApplicationServices.GetServices<OcelotMiddlewareConfigurationDelegate>();
            foreach (var configuration in configurations)
            {
                await configuration(builder);
            }
            return GetOcelotConfigAndReturn(internalConfigRepo);
        }

        private static bool IsError(Response response)
        {
            return response == null || response.IsError;
        }

        private static IInternalConfiguration GetOcelotConfigAndReturn(IInternalConfigurationRepository provider)
        {
            var ocelotConfiguration = provider.Get();

            if (ocelotConfiguration?.Data == null || ocelotConfiguration.IsError)
            {
                ThrowToStopOcelotStarting(ocelotConfiguration);
            }

            return ocelotConfiguration.Data;
        }

        private static void ThrowToStopOcelotStarting(Response config)
        {
            throw new Exception($"Unable to start Ocelot, errors are: {string.Join(",", config.Errors.Select(x => x.ToString()))}");
        }

        private static void ConfigureDiagnosticListener(IApplicationBuilder builder)
        {
            var env = builder.ApplicationServices.GetService<IHostingEnvironment>();
            var listener = builder.ApplicationServices.GetService<OcelotDiagnosticListener>();
            var diagnosticListener = builder.ApplicationServices.GetService<DiagnosticListener>();
            diagnosticListener.SubscribeWithAdapter(listener);
        }
    }
}
