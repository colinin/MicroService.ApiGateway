using AutoMapper;
using MicroService.ApiGateway.Entites.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using MicroService.ApiGateway.Snowflake;
using Volo.Abp.DependencyInjection;

namespace MicroService.ApiGateway
{
    public class ApiGatewayApplicationAutoMapperProfile : Profile, ISingletonDependency
    {
        public ApiGatewayApplicationAutoMapperProfile(ISnowflakeIdGenerator snowflakeIdGenerator)
        {
            //Configure your AutoMapper mapping configuration here...

            CreateMap<CacheOptions, CacheOptionsDto>();

            CreateMap<QoSOptions, QosOptionsDto>();

            CreateMap<LoadBalancerOptions, LoadBalancerOptionsDto>();

            CreateMap<RateLimitOptions, RateLimitOptionsDto>();

            CreateMap<RateLimitRule, RateLimitRuleDto>()
                .ForMember(dto => dto.ClientWhitelist, map => map.MapFrom(m => m.ClientWhitelist.Split(',')));

            CreateMap<AuthenticationOptions, AuthenticationOptionsDto>()
                .ForMember(dto => dto.AllowedScopes, map => map.MapFrom(m => m.AllowedScopes.Split(',')));

            CreateMap<HttpHandlerOptions, HttpHandlerOptionsDto>();

            CreateMap<HostAndPort, HostAndPortDto>();

            CreateMap<SecurityOptions, SecurityOptionsDto>()
                .ForMember(dto => dto.IPAllowedList, map => map.MapFrom(m => m.IPAllowedList.Split(',')))
                .ForMember(dto => dto.IPBlockedList, map => map.MapFrom(m => m.IPBlockedList.Split(',')));

            CreateMap<GlobalConfiguration, GlobalConfigurationDto>();

            CreateMap<DynamicReRoute, DynamicReRouteDto>();

            CreateMap<ReRoute, ReRouteDto>();

            CreateMap<ReRouteDto, ReRoute>()
                .ForCtorParam("rerouteId", x => x.MapFrom(m => snowflakeIdGenerator.NextId()))
                .ForCtorParam("routeName", x => x.MapFrom(m => m.ReRouteName))
                .ForCtorParam("downPath", x => x.MapFrom(m => m.DownstreamPathTemplate))
                .ForCtorParam("upPath", x => x.MapFrom(m => m.UpstreamPathTemplate))
                .ForCtorParam("upMethod", x => x.MapFrom(m => m.UpstreamHttpMethod))
                .ForCtorParam("downHost", x => x.MapFrom(m => m.DownstreamHostAndPorts))
                .ForMember(map => map.QoSOptions, dto => dto.Ignore())
                .ForMember(map => map.CacheOptions, dto => dto.Ignore())
                .ForMember(map => map.LoadBalancerOptions, dto => dto.Ignore())
                .ForMember(map => map.RateLimitOptions, dto => dto.Ignore())
                .ForMember(map => map.AuthenticationOptions, dto => dto.Ignore())
                .ForMember(map => map.HttpHandlerOptions, dto => dto.Ignore())
                .ForMember(map => map.SecurityOptions, dto => dto.Ignore());
        }
    }
}
