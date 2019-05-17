namespace MicroService.ApiGateway.Ocelot.Dto
{
    public class GlobalConfigurationDto
    {
        public string RequestIdKey { get; set; }

        public ServiceDiscoveryProviderDto ServiceDiscoveryProvider { get; set; }

        public RateLimitOptionsDto RateLimitOptions { get; set; }

        public QosOptionsDto QoSOptions { get; set; }

        public string BaseUrl { get; set; }

        public LoadBalancerOptionsDto LoadBalancerOptions { get; set; }

        public string DownstreamScheme { get; set; }

        public HttpHandlerOptionsDto HttpHandlerOptions { get; set; }
    }
}
