using AutoMapper;
using MicroService.ApiGateway.Ocelot.Dto;
using Ocelot.Configuration.File;

namespace MicroService.ApiGateway
{
    public class ApiGatewayWebAutoMapperProfile : Profile
    {
        public ApiGatewayWebAutoMapperProfile()
        {
            //Configure your AutoMapper mapping configuration here...
            CreateMap<HostAndPortDto, FileHostAndPort>();
            CreateMap<HttpHandlerOptionsDto, FileHttpHandlerOptions>();
            CreateMap<AuthenticationOptionsDto, FileAuthenticationOptions>();
            CreateMap<RateLimitRuleDto, FileRateLimitRule>();
            CreateMap<LoadBalancerOptionsDto, FileLoadBalancerOptions>();
            CreateMap<QosOptionsDto, FileQoSOptions>();
            CreateMap<CacheOptionsDto, FileCacheOptions>();
            CreateMap<SecurityOptionsDto, FileSecurityOptions>();
            CreateMap<ServiceDiscoveryProviderDto, FileServiceDiscoveryProvider>();
            CreateMap<RateLimitOptionsDto, FileRateLimitOptions>();

            CreateMap<ReRouteDto, FileReRoute>();
            CreateMap<GlobalConfigurationDto, FileGlobalConfiguration>();
            CreateMap<DynamicReRouteDto, FileDynamicReRoute>();
        }
    }
}
