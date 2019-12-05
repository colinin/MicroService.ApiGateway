using AutoMapper;
using MicroService.ApiGateway.Ocelot.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MicroService.ApiGateway
{
    public class ApiGatewayWebAutoMapperProfile : Profile
    {
        public ApiGatewayWebAutoMapperProfile()
        {
            //Configure your AutoMapper mapping configuration here...
            CreateMap<AggregateReRouteDto, AggregateReRouteModel>();
            CreateMap<DynamicReRouteDto, DynamicReRouteModel>();
            CreateMap<ReRouteDto, ReRouteModel>()
                .ForMember(model => model.UpstreamHttpMethod, src => src.MapFrom((m, n) =>
                {
                    if (m.UpstreamHttpMethod.IsNullOrWhiteSpace())
                    {
                        return new List<string>();
                    }
                    return m.UpstreamHttpMethod.Split(';').ToList();
                }))
                .ForMember(model => model.DelegatingHandlers, src => src.MapFrom((m, n) =>
                {
                    if (m.DelegatingHandlers.IsNullOrWhiteSpace())
                    {
                        return new List<string>();
                    }
                    return m.DelegatingHandlers.Split(';').ToList();
                }))
                .ForMember(model => model.AddClaimsToRequest, src => src.MapFrom((m, n) =>
                {
                    var addClaimsToRequests = new Dictionary<string, string>();
                    if (!m.AddClaimsToRequest.IsNullOrWhiteSpace())
                    {
                        var headerStrings = m.AddClaimsToRequest.Split(';');
                        foreach (var headerString in headerStrings)
                        {
                            if (headerString.Contains(":"))
                            {
                                var header = headerString.Split(':');
                                addClaimsToRequests.Add(header[0], header[1]);
                            }
                        }
                    }
                    return addClaimsToRequests;
                }))
                .ForMember(model => model.AddHeadersToRequest, src => src.MapFrom((m, n) =>
                {
                    var addHeadersToRequests = new Dictionary<string, string>();
                    if (!m.AddHeadersToRequest.IsNullOrWhiteSpace())
                    {
                        var headerStrings = m.AddHeadersToRequest.Split(';');
                        foreach (var headerString in headerStrings)
                        {
                            if (headerString.Contains(":"))
                            {
                                var header = headerString.Split(':');
                                addHeadersToRequests.Add(header[0], header[1]);
                            }
                        }
                    }
                    return addHeadersToRequests;
                }))
                .ForMember(model => model.UpstreamHeaderTransform, src => src.MapFrom((m, n) =>
                 {
                     var upstreamHeaderTransform = new Dictionary<string, string>();
                     if (!m.UpstreamHeaderTransform.IsNullOrWhiteSpace())
                     {
                         var headerStrings = m.UpstreamHeaderTransform.Split(';');
                         foreach (var headerString in headerStrings)
                         {
                             if (headerString.Contains(":"))
                             {
                                 var header = headerString.Split(':');
                                 upstreamHeaderTransform.Add(header[0], header[1]);
                             }
                         }
                     }
                     return upstreamHeaderTransform;
                 }))
                .ForMember(model => model.DownstreamHeaderTransform, src => src.MapFrom((m, n) =>
                 {
                     var downstreamHeaderTransform = new Dictionary<string, string>();
                     if (!m.DownstreamHeaderTransform.IsNullOrWhiteSpace())
                     {
                         var headerStrings = m.DownstreamHeaderTransform.Split(';');
                         foreach (var headerString in headerStrings)
                         {
                             if (headerString.Contains(":"))
                             {
                                 var header = headerString.Split(':');
                                 downstreamHeaderTransform.Add(header[0], header[1]);
                             }
                         }
                     }
                     return downstreamHeaderTransform;
                 }))
                .ForMember(model => model.RouteClaimsRequirement, src => src.MapFrom((m, n) =>
                 {
                     var routeClaimsRequirement = new Dictionary<string, string>();
                     if (!m.RouteClaimsRequirement.IsNullOrWhiteSpace())
                     {
                         var headerStrings = m.RouteClaimsRequirement.Split(';');
                         foreach (var headerString in headerStrings)
                         {
                             if (headerString.Contains(":"))
                             {
                                 var header = headerString.Split(':');
                                 routeClaimsRequirement.Add(header[0], header[1]);
                             }
                         }
                     }
                     return routeClaimsRequirement;
                 }))
                .ForMember(model => model.AddQueriesToRequest, src => src.MapFrom((m, n) =>
                 {
                     var addQueriesToRequest = new Dictionary<string, string>();
                     if (!m.AddQueriesToRequest.IsNullOrWhiteSpace())
                     {
                         var headerStrings = m.AddQueriesToRequest.Split(';');
                         foreach (var headerString in headerStrings)
                         {
                             if (headerString.Contains(":"))
                             {
                                 var header = headerString.Split(':');
                                 addQueriesToRequest.Add(header[0], header[1]);
                             }
                         }
                     }
                     return addQueriesToRequest;
                 }))
                .ForMember(model => model.DownstreamHostAndPorts, src => src.MapFrom((m, n) =>
                {
                    var downHostAndPorts = new List<HostAndPortModel>();
                    var hostAndPorts = m.DownstreamHostAndPorts.Split(',');
                    foreach (var hostAndPort in hostAndPorts)
                    {
                        if (hostAndPort.Contains(":"))
                        {
                            var hostPort = hostAndPort.Split(':');
                            downHostAndPorts.Add(new HostAndPortModel
                            {
                                Host = hostPort[0],
                                Port = int.Parse(hostPort[1])
                            });
                        }
                    }
                    return downHostAndPorts;
                }));
            CreateMap<GlobalConfigurationDto, GlobalConfigurationModel>();
        }
    }
}
