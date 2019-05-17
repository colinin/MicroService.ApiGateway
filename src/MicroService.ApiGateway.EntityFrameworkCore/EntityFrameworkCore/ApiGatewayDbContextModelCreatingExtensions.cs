using MicroService.ApiGateway.Entites.Ocelot;
using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MicroService.ApiGateway.EntityFrameworkCore
{
    public static class ApiGatewayDbContextModelCreatingExtensions
    {
        public static void ConfigureApiGateway(
            this ModelBuilder builder,
            Action<ApiGatewayModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ApiGatewayModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<CacheOptions>(e =>
            {
                e.ToTable(options.TablePrefix + "CacheOptions", options.Schema);

                e.Property(p => p.ReRouteId).IsRequired();
                e.Property(p => p.Region).HasMaxLength(256);
            });

            builder.Entity<AuthenticationOptions>(e =>
            {
                e.ToTable(options.TablePrefix + "AuthOptions", options.Schema);

                e.Property(p => p.ReRouteId).IsRequired();
                e.Property(p => p.AllowedScopes).HasMaxLength(200);
                e.Property(p => p.AuthenticationProviderKey).HasMaxLength(100);
            });

            builder.Entity<Headers>(e =>
            {
                e.ToTable(options.TablePrefix + "Headers", options.Schema);

                e.Property(p => p.ReRouteId).IsRequired();
                e.Property(p => p.Key).HasMaxLength(50);
                e.Property(p => p.Value).HasMaxLength(256);
            });

            builder.Entity<HostAndPort>(e =>
            {
                e.ToTable(options.TablePrefix + "HostAndPort", options.Schema);

                e.Property(p => p.ReRouteId).IsRequired();
            });

            builder.Entity<HttpHandlerOptions>(e =>
            {
                e.ToTable(options.TablePrefix + "HttpOptions", options.Schema);

                e.Property(p => p.ItemId).IsRequired();
            });

            builder.Entity<LoadBalancerOptions>(e =>
            {
                e.ToTable(options.TablePrefix + "BalancerOptions", options.Schema);

                e.Property(p => p.ItemId).IsRequired();
                e.Property(p => p.Type).HasMaxLength(100);
                e.Property(p => p.Key).HasMaxLength(100);
            });

            builder.Entity<QoSOptions>(e =>
            {
                e.ToTable(options.TablePrefix + "QoSOptions", options.Schema);

                e.Property(p => p.ItemId).IsRequired();
            });

            builder.Entity<RateLimitOptions>(e =>
            {
                e.ToTable(options.TablePrefix + "RateLimitOptions", options.Schema);

                e.Property(p => p.ItemId).IsRequired();
                e.Property(p => p.ClientIdHeader).HasMaxLength(50);
                e.Property(p => p.QuotaExceededMessage).HasMaxLength(256);
                e.Property(p => p.RateLimitCounterPrefix).HasMaxLength(50);
            });

            builder.Entity<RateLimitRule>(e =>
            {
                e.ToTable(options.TablePrefix + "RateLimitRule", options.Schema);

                e.Property(p => p.ReRouteId).IsRequired();
                e.Property(p => p.Period).HasMaxLength(50);
                e.Property(p => p.ClientWhitelist).HasMaxLength(1000);
            });

            builder.Entity<SecurityOptions>(e =>
            {
                e.ToTable(options.TablePrefix + "SecurityOptions", options.Schema);

                e.Property(p => p.ReRouteId).IsRequired();
                e.Property(p => p.IPAllowedList).HasMaxLength(1000);
                e.Property(p => p.IPBlockedList).HasMaxLength(1000);
            });

            builder.Entity<ServiceDiscoveryProvider>(e =>
            {
                e.ToTable(options.TablePrefix + "Discovery", options.Schema);

                e.Property(p => p.ItemId).IsRequired();
                e.Property(p => p.Host).HasMaxLength(50);
                e.Property(p => p.Type).HasMaxLength(128);
                e.Property(p => p.Token).HasMaxLength(256);
                e.Property(p => p.Namespace).HasMaxLength(128);
                e.Property(p => p.ConfigurationKey).HasMaxLength(256);
            });

            builder.Entity<DynamicReRoute>(e =>
            {
                e.ToTable(options.TablePrefix + "DynamicReRoute", options.Schema);

                e.Property(p => p.DunamicReRouteId).IsRequired();
                e.Property(p => p.ServiceName).IsRequired().HasMaxLength(100);
            });

            builder.Entity<GlobalConfiguration>(e =>
            {
                e.ToTable(options.TablePrefix + "GlobalConfiguration", options.Schema);

                e.Property(p => p.ItemId).IsRequired();
                e.Property(p => p.RequestIdKey).HasMaxLength(100);
                e.Property(p => p.BaseUrl).IsRequired().HasMaxLength(256);
                e.Property(p => p.DownstreamScheme).IsRequired().HasMaxLength(100);
            });

            builder.Entity<ReRoute>(e =>
            {
                e.ToTable(options.TablePrefix + "ReRoute", options.Schema);

                e.Property(p => p.ReRouteId).IsRequired();
                e.Property(p => p.RequestIdKey).HasMaxLength(100);
                e.Property(p => p.DownstreamScheme).HasMaxLength(100);
                e.Property(p => p.DownstreamPathTemplate).IsRequired().HasMaxLength(100);
                e.Property(p => p.UpstreamPathTemplate).IsRequired().HasMaxLength(100);
                e.Property(p => p.UpstreamHttpMethod).IsRequired().HasMaxLength(50);
                e.Property(p => p.ServiceName).HasMaxLength(100);
                e.Property(p => p.UpstreamHost).HasMaxLength(100);
                e.Property(p => p.Key).HasMaxLength(100);

                e.Property(x => x.AddHeadersToRequest).HasMaxLength(1000);
                e.Property(x => x.UpstreamHeaderTransform).HasMaxLength(1000);
                e.Property(x => x.DownstreamHeaderTransform).HasMaxLength(1000);
                e.Property(x => x.AddClaimsToRequest).HasMaxLength(1000);
                e.Property(x => x.RouteClaimsRequirement).HasMaxLength(1000);
                e.Property(x => x.AddQueriesToRequest).HasMaxLength(1000);
                e.Property(x => x.DownstreamHostAndPorts).HasMaxLength(1000);

                e.ConfigureConcurrencyStamp();
            });
        }
    }
}
