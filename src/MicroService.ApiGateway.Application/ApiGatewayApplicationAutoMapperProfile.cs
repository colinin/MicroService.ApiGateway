using AutoMapper;
using MicroService.ApiGateway.Entites.Ocelot;
using MicroService.ApiGateway.Ocelot.Dto;
using MicroService.ApiGateway.Snowflake;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
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

            CreateMap<RateLimitOptions, RateLimitRuleDto>();

            CreateMap<AuthenticationOptions, AuthenticationOptionsDto>();

            CreateMap<HttpHandlerOptions, HttpHandlerOptionsDto>();

            CreateMap<HostAndPort, HostAndPortDto>();

            CreateMap<SecurityOptions, SecurityOptionsDto>();

            CreateMap<GlobalConfiguration, GlobalConfigurationDto>();

            CreateMap<DynamicReRoute, DynamicReRouteDto>();

            CreateMap<ReRoute, ReRouteDto>()
                .ForMember(dto => dto.AddClaimsToRequest, map => map.MapFrom(m => MapperDictionary(m.AddClaimsToRequest)))
                .ForMember(dto => dto.AddHeadersToRequest, map => map.MapFrom(m => MapperDictionary(m.AddHeadersToRequest)))
                .ForMember(dto => dto.AddQueriesToRequest, map => map.MapFrom(m => MapperDictionary(m.AddQueriesToRequest)))
                .ForMember(dto => dto.DelegatingHandlers, map => map.MapFrom(m => MapperList(m.DelegatingHandlers)))
                .ForMember(dto => dto.DownstreamHeaderTransform, map => map.MapFrom(m => MapperDictionary(m.DownstreamHeaderTransform)))
                .ForMember(dto => dto.RouteClaimsRequirement, map => map.MapFrom(m => MapperDictionary(m.RouteClaimsRequirement)))
                .ForMember(dto => dto.UpstreamHeaderTransform, map => map.MapFrom(m => MapperDictionary(m.UpstreamHeaderTransform)))
                .ForMember(dto => dto.UpstreamHttpMethod, map => map.MapFrom(m => MapperList(m.UpstreamHttpMethod)))
                .ForMember(dto => dto.DownstreamHostAndPorts, map => map.MapFrom(m => MapperJson<HostAndPort>(m.DownstreamHostAndPorts)))
                .ForMember(dto => dto.FileCacheOptions, map => map.MapFrom(m => m.CacheOptions));

            CreateMap<ReRouteDto, ReRoute>()
                .ForCtorParam("rerouteId", x => x.MapFrom(m => snowflakeIdGenerator.NextId()))
                .ForCtorParam("routeName", x => x.MapFrom(m => m.ReRouteName))
                .ForCtorParam("downPath", x => x.MapFrom(m => m.DownstreamPathTemplate))
                .ForCtorParam("upPath", x => x.MapFrom(m => m.UpstreamPathTemplate))
                .ForCtorParam("upMethod", x => x.MapFrom(m => m.UpstreamHttpMethod.JoinAsString(";")));
        }

        private Dictionary<string, string> MapperDictionary(string sourceString)
        {
            var dictionary = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(sourceString))
            {
                var headers = sourceString.Split(';').ToList();

                if (headers != null && headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        var current = header.Split(':');
                        if (current != null && current.Length == 2)
                        {
                            dictionary.Add(current[0], current[1]);
                        }
                    }
                }
            }
            return dictionary;
        }

        private List<string> MapperList(string sourceString)
        {
            var list = new List<string>();
            if (!string.IsNullOrWhiteSpace(sourceString))
            {
                list = sourceString.Split(';').ToList();
            }
            return list;
        }

        private List<T> MapperJson<T>(string sourceString)
        {
            if (!string.IsNullOrWhiteSpace(sourceString))
            {
                return JsonConvert.DeserializeObject<List<T>>(sourceString);
            }

            return new List<T>();
        }
    }
}
