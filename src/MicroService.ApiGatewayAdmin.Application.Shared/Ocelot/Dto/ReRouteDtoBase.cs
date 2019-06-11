using System;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class ReRouteDtoBase
    {
        public string DownstreamPathTemplate { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public string UpstreamHttpMethod { get; set; }
        public string AddHeadersToRequest { get; set; }
        public string UpstreamHeaderTransform { get; set; }
        public string DownstreamHeaderTransform { get; set; }
        public string AddClaimsToRequest { get; set; }
        public string RouteClaimsRequirement { get; set; }
        public string AddQueriesToRequest { get; set; }
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
        public string DownstreamHostAndPorts { get; set; }
        public string UpstreamHost { get; set; }
        public string Key { get; set; }
        public string DelegatingHandlers { get; set; }
        public int? Priority { get; set; }
        public int? Timeout { get; set; }
        public bool DangerousAcceptAnyServerCertificateValidator { get; set; }
        public SecurityOptionsDto SecurityOptions { get; set; }

        public ReRouteDtoBase()
        {
            FileCacheOptions = new CacheOptionsDto();
            QoSOptions = new QosOptionsDto();
            LoadBalancerOptions = new LoadBalancerOptionsDto();
            RateLimitOptions = new RateLimitRuleDto();
            AuthenticationOptions = new AuthenticationOptionsDto();
            HttpHandlerOptions = new HttpHandlerOptionsDto();
            SecurityOptions = new SecurityOptionsDto();
        }
    }
}
