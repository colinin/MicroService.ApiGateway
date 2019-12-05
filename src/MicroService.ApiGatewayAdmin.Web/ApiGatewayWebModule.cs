using Localization.Resources.AbpUi;
using MicroService.ApiGateway.Authentication;
using MicroService.ApiGateway.Bundling;
using MicroService.ApiGateway.EntityFrameworkCore;
using MicroService.ApiGatewayAdmin.Domain.Localization.ApiGateway;
using MicroService.ApiGateway.Menus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Localization;
using Volo.Abp.Localization.Resources.AbpValidation;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Timing;
using Serilog;

namespace MicroService.ApiGateway
{
    [DependsOn(
        typeof(ApiGatewayApplicationModule),
        typeof(ApiGatewayEntityFrameworkCoreModule),
        typeof(AbpHttpClientIdentityModelModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMvcUiLayuiThemeModule)
        )]
    public class ApiGatewayWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(ApiGatewayResource),
                    typeof(ApiGatewayDomainModule).Assembly,
                    typeof(ApiGatewayApplicationModule).Assembly,
                    typeof(ApiGatewayWebModule).Assembly
                );
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(configuration)
               .CreateLogger();

            Configure<ClockOptions>(options =>
            {
                options.Kind = System.DateTimeKind.Local;
            });

            ConfigureIdentityAuthentication(context.Services, configuration.GetSection("Identity"));
            ConfigureDatabaseServices();
            ConfigureAutoMapper();
            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            ConfigureNavigationServices();
            ConfigureAutoApiControllers();
            ConfigureSwaggerServices(context.Services);
            ConfigureBundling();
            ConfigureCAP(context.Services, configuration);
        }

        private void ConfigureCAP(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCap(x =>
            {
                x.UseEntityFramework<ApiGatewayDbContext>();

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

        private void ConfigureBundling()
        {
            Configure<BundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(WebServiceBundles.Styles.TagsInput, bundle => bundle.AddFiles("/libs/bootstrap/css/bootstrap.tagsinput.css"))
                    .Add(WebServiceBundles.Styles.DateTimePicker, bundle => bundle.AddFiles("/libs/datetimepicker/css/bootstrap-datepicker3.min.css"))
                    .Add(WebServiceBundles.Styles.OcelotGlobal, bundle => bundle.AddFiles("/css/ocelot/global.css"))
                    .Add(WebServiceBundles.Styles.OcelotReRoute, bundle => bundle.AddFiles("/css/ocelot/reroute.css"))
                    .Add(WebServiceBundles.Styles.OcelotReRoutes, bundle => bundle.AddFiles("/css/ocelot/reroutes.css"));

                options
                    .ScriptBundles
                    .Add(WebServiceBundles.Scripts.Echarts, bundle => bundle.AddFiles("/libs/echarts/4.2.1/echarts.min.js"))
                    .Add(WebServiceBundles.Scripts.TagsInput, bundle => bundle.AddFiles("/libs/bootstrap/js/bootstrap.tagsinput.js"))
                    .Add(WebServiceBundles.Scripts.JavaScriptLinq, bundle => bundle.AddFiles("/libs/linq/linq.min.js"))
                    .Add(WebServiceBundles.Scripts.DateTimePicker, bundle => bundle.AddFiles(
                        "/libs/datetimepicker/bootstrap-datepicker.min.js", "/libs/datetimepicker/locales/bootstrap-datepicker.zh-CN.min.js"))
                    .Add(WebServiceBundles.Scripts.OcelotGlobal, bundle => bundle.AddFiles("/js/ocelot/global.js"))
                    .Add(WebServiceBundles.Scripts.OcelotReRoute, bundle => bundle.AddFiles("/js/ocelot/reroute.js"))
                    .Add(WebServiceBundles.Scripts.OcelotReRoutes, bundle => bundle.AddFiles("/js/ocelot/reroutes.js"))
                    .Add(WebServiceBundles.Scripts.OcelotSource, bundle => bundle.AddFiles("/js/ocelot/source.js"));
            });
        }

        private void ConfigureIdentityAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = AuthenticationConsts.CookieName;
                options.DefaultChallengeScheme = AuthenticationConsts.OidcAuthenticationScheme;
            })
            .AddCookie(AuthenticationConsts.CookieName)
            .AddAutomaticTokenManagement()
            .AddOpenIdConnect(AuthenticationConsts.OidcAuthenticationScheme, options =>
            {
                options.SignInScheme = AuthenticationConsts.CookieName;
                options.Authority = configuration.GetValue<string>("Host");
                //options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                options.RequireHttpsMetadata = false;

                options.ClientId = configuration.GetValue<string>("ClientId");
                options.ClientSecret = configuration.GetValue<string>("ClientSecret");

                options.Scope.Clear();
                options.Scope.Add(AuthenticationConsts.ScopeOpenId);
                options.Scope.Add(AuthenticationConsts.ScopeProfile);
                options.Scope.Add(AuthenticationConsts.ScopeEmail);
                options.Scope.Add(AuthenticationConsts.ScopeRoles);
                options.Scope.Add(AuthenticationConsts.ScopeCustomProfile);
                options.Scope.Add(AuthenticationConsts.ScopeRefreshToken);

                options.SaveTokens = true;

                options.GetClaimsFromUserInfoEndpoint = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role",
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthenticationConsts.AdministrationPolicy,
                    policy => policy.RequireRole(AuthenticationConsts.AdministrationRole));
            });
        }

        private void ConfigureDatabaseServices()
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseMySQL();
            });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ApiGatewayWebAutoMapperProfile>();
            });
        }

        private void ConfigureVirtualFileSystem(IHostingEnvironment hostingEnvironment)
        {
            //if (hostingEnvironment.IsDevelopment())
            //{
            //    Configure<VirtualFileSystemOptions>(options =>
            //    {
            //        options.FileSets.ReplaceEmbeddedByPhysical<ApiGatewayDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}MicroService.ApiGatewayAdmin.Domain", Path.DirectorySeparatorChar)));
            //    });
            //}
        }

        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ApiGatewayResource>()
                    .AddVirtualJson("/MicroService/ApiGatewayAdmin/Web/Localization/ApiGateway");

                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            });
        }

        private void ConfigureNavigationServices()
        {
            Configure<NavigationOptions>(options =>
            {
                options.MenuContributors.Add(new WebServiceMenuContributor());
            });
        }

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(ApiGatewayApplicationModule).Assembly);
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new Info { Title = "MicroService.ApiGatewayAdmin API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseErrorPage();
            }
            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseAuthentication();
            app.UseAbpRequestLocalization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "MicroService.ApiGatewayAdmin API");
            });

            app.UseAuditing();

            app.UseMvcWithDefaultRouteAndArea();
        }
    }
}
