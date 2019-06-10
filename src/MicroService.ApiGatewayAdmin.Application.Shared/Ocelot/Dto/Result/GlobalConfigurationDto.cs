using Newtonsoft.Json;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    public class GlobalConfigurationDto
    {
        [JsonConverter(typeof(HexLongConverter))]
        public long ItemId { get;  set; }
        public string RequestIdKey { get; set; }

        public ServiceDiscoveryProviderDto ServiceDiscoveryProvider { get; set; }

        public RateLimitOptionsDto RateLimitOptions { get; set; }

        public QosOptionsDto QoSOptions { get; set; }

        public string BaseUrl { get; set; }

        public LoadBalancerOptionsDto LoadBalancerOptions { get; set; }

        public string DownstreamScheme { get; set; }

        public HttpHandlerOptionsDto HttpHandlerOptions { get; set; }

        public GlobalConfigurationDto()
        {
            ServiceDiscoveryProvider = new ServiceDiscoveryProviderDto();
            RateLimitOptions = new RateLimitOptionsDto();
            QoSOptions = new QosOptionsDto();
            LoadBalancerOptions = new LoadBalancerOptionsDto();
            HttpHandlerOptions = new HttpHandlerOptionsDto();
        }
    }
}
