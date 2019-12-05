using AutoMapper;
using MicroService.ApiGateway.Ocelot.Dto;
using Newtonsoft.Json;
using Ocelot.Configuration.File;
using System.Collections.Generic;
using System.Linq;

namespace MicroService.ApiGateway
{
    public class MicroServiceApiGatewayMapperProfile : Profile
    {
        public MicroServiceApiGatewayMapperProfile()
        {
            //Configure your AutoMapper mapping configuration here...
            CreateMap<HostAndPortDto, FileHostAndPort>()
                .ForMember(fhp => fhp.Port, map => map.MapFrom(m => m.Port ?? 0));
            CreateMap<HttpHandlerOptionsDto, FileHttpHandlerOptions>();
            CreateMap<AuthenticationOptionsDto, FileAuthenticationOptions>();
            CreateMap<RateLimitRuleDto, FileRateLimitRule>()
                .ForMember(frl => frl.Limit, map => map.MapFrom(m => m.Limit ?? 0L))
                .ForMember(frl => frl.PeriodTimespan, map => map.MapFrom(m => m.PeriodTimespan ?? 0d));
            CreateMap<LoadBalancerOptionsDto, FileLoadBalancerOptions>()
                .ForMember(flb => flb.Expiry, map => map.MapFrom(m => m.Expiry ?? 0));
            CreateMap<QosOptionsDto, FileQoSOptions>()
                .ForMember(fqs => fqs.DurationOfBreak, map => map.MapFrom(m => m.DurationOfBreak ?? 0))
                .ForMember(fqs => fqs.ExceptionsAllowedBeforeBreaking, map => map.MapFrom(m => m.ExceptionsAllowedBeforeBreaking ?? 0))
                .ForMember(fqs => fqs.TimeoutValue, map => map.MapFrom(m => m.TimeoutValue ?? 0));
            CreateMap<CacheOptionsDto, FileCacheOptions>()
                .ForMember(fco => fco.TtlSeconds, map => map.MapFrom(m => m.TtlSeconds ?? 0));
            CreateMap<SecurityOptionsDto, FileSecurityOptions>();
            CreateMap<ServiceDiscoveryProviderDto, FileServiceDiscoveryProvider>()
                .ForMember(fsd => fsd.Port, map => map.MapFrom(m => m.Port ?? 0))
                .ForMember(fsd => fsd.PollingInterval, map => map.MapFrom(m => m.PollingInterval ?? 0));
            CreateMap<RateLimitOptionsDto, FileRateLimitOptions>()
                .ForMember(flo => flo.HttpStatusCode, map => map.MapFrom(m => m.HttpStatusCode ?? 429));

            CreateMap<ReRouteDto, FileReRoute>()
                .ForMember(frr => frr.AddClaimsToRequest, map => map.MapFrom(m => MapperDictionary(m.AddClaimsToRequest)))
                .ForMember(frr => frr.AddHeadersToRequest, map => map.MapFrom(m => MapperDictionary(m.AddHeadersToRequest)))
                .ForMember(frr => frr.AddQueriesToRequest, map => map.MapFrom(m => MapperDictionary(m.AddQueriesToRequest)))
                .ForMember(frr => frr.DelegatingHandlers, map => map.MapFrom(m => MapperList(m.DelegatingHandlers)))
                .ForMember(frr => frr.DownstreamHeaderTransform, map => map.MapFrom(m => MapperDictionary(m.DownstreamHeaderTransform)))
                .ForMember(frr => frr.RouteClaimsRequirement, map => map.MapFrom(m => MapperDictionary(m.RouteClaimsRequirement)))
                .ForMember(frr => frr.UpstreamHeaderTransform, map => map.MapFrom(m => MapperDictionary(m.UpstreamHeaderTransform)))
                .ForMember(frr => frr.UpstreamHttpMethod, map => map.MapFrom(m => MapperList(m.UpstreamHttpMethod)))
                .ForMember(frr => frr.DownstreamHostAndPorts, map => map.MapFrom(m => MapperHostAndPortList(m.DownstreamHostAndPorts)))
                .ForMember(frr => frr.FileCacheOptions, map => map.MapFrom(m => m.FileCacheOptions))
                .ForMember(frr => frr.Priority, map => map.MapFrom(m => m.Priority ?? 0))
                .ForMember(frr => frr.Timeout, map => map.MapFrom(m => m.Timeout ?? 0));

            CreateMap<GlobalConfigurationDto, FileGlobalConfiguration>()
                .ForMember(fgc => fgc.HttpHandlerOptions, map => map.MapFrom(m => m.HttpHandlerOptions))
                .ForMember(fgc => fgc.LoadBalancerOptions, map => map.MapFrom(m => m.LoadBalancerOptions))
                .ForMember(fgc => fgc.QoSOptions, map => map.MapFrom(m => m.QoSOptions))
                .ForMember(fgc => fgc.RateLimitOptions, map => map.MapFrom(m => m.RateLimitOptions))
                .ForMember(fgc => fgc.ServiceDiscoveryProvider, map => map.MapFrom(m => m.ServiceDiscoveryProvider));

            CreateMap<DynamicReRouteDto, FileDynamicReRoute>();
        }

        private Dictionary<string, string> MapperDictionary(string sourceString)
        {
            var dictionary = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(sourceString))
            {
                var headers = sourceString.Split(',').ToList();

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
            if (!string.IsNullOrWhiteSpace(sourceString) && sourceString.Contains(","))
            {
                list = sourceString.Split(',').ToList();
            }
            return list;
        }

        private List<FileHostAndPort> MapperHostAndPortList(string sourceString)
        {
            var list = new List<FileHostAndPort>();
            if (!string.IsNullOrWhiteSpace(sourceString) && sourceString.Contains(","))
            {
                var sourceList = sourceString.Split(',').ToList();
                foreach (var source in sourceList)
                {
                    var current = source.Split(':');
                    if (current != null && current.Length == 2)
                    {
                        var hostAndPort = new FileHostAndPort();
                        hostAndPort.Host = current[0];
                        hostAndPort.Port = int.Parse(current[1]);
                        list.Add(hostAndPort);
                    }
                }
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
