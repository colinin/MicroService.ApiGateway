using System;
using System.Collections.Generic;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class ReRouteModel
    {
        public string DownstreamPathTemplate { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public List<string> UpstreamHttpMethod { get; set; }
        public Dictionary<string, string> AddHeadersToRequest { get; set; }
        public Dictionary<string, string> UpstreamHeaderTransform { get; set; }
        public Dictionary<string, string> DownstreamHeaderTransform { get; set; }
        public Dictionary<string, string> AddClaimsToRequest { get; set; }
        public Dictionary<string, string> RouteClaimsRequirement { get; set; }
        public Dictionary<string, string> AddQueriesToRequest { get; set; }
        public string RequestIdKey { get; set; }
        public CacheOptionsDto FileCacheOptions { get; set; }
        public bool ReRouteIsCaseSensitive { get; set; }
        public string ServiceName { get; set; }
        public string DownstreamScheme { get; set; }
        public QosOptionsDto QoSOptions { get; set; }
        public LoadBalancerOptionsDto LoadBalancerOptions { get; set; }
        public RateLimitRuleDto RateLimitOptions { get; set; }
        public AuthenticationOptionsDto AuthenticationOptions { get; set; }
        public HttpHandlerOptionsDto HttpHandlerOptions { get; set; }
        public List<HostAndPortModel> DownstreamHostAndPorts { get; set; }
        public string UpstreamHost { get; set; }
        public string Key { get; set; }
        public List<string> DelegatingHandlers { get; set; }
        public int? Priority { get; set; }
        public int? Timeout { get; set; }
        public bool DangerousAcceptAnyServerCertificateValidator { get; set; }
        public SecurityOptionsDto SecurityOptions { get; set; }

        public ReRouteModel()
        {
            FileCacheOptions = new CacheOptionsDto();
            QoSOptions = new QosOptionsDto();
            LoadBalancerOptions = new LoadBalancerOptionsDto();
            RateLimitOptions = new RateLimitRuleDto();
            AuthenticationOptions = new AuthenticationOptionsDto();
            HttpHandlerOptions = new HttpHandlerOptionsDto();
            SecurityOptions = new SecurityOptionsDto();
            DownstreamHostAndPorts = new List<HostAndPortModel>();
            DelegatingHandlers = new List<string>();
            UpstreamHttpMethod = new List<string>();
            AddHeadersToRequest = new Dictionary<string, string>();
            UpstreamHeaderTransform = new Dictionary<string, string>();
            DownstreamHeaderTransform = new Dictionary<string, string>();
            AddClaimsToRequest = new Dictionary<string, string>();
            RouteClaimsRequirement = new Dictionary<string, string>();
            AddQueriesToRequest = new Dictionary<string, string>();
        }
    }
}
