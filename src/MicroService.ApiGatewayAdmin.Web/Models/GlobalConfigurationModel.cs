using System;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class GlobalConfigurationModel
    {
        public string RequestIdKey { get; set; }

        public ServiceDiscoveryProviderDto ServiceDiscoveryProvider { get; set; }

        public RateLimitOptionsDto RateLimitOptions { get; set; }

        public QosOptionsDto QoSOptions { get; set; }

        public string BaseUrl { get; set; }

        public LoadBalancerOptionsDto LoadBalancerOptions { get; set; }

        public string DownstreamScheme { get; set; }

        public HttpHandlerOptionsDto HttpHandlerOptions { get; set; }

        public GlobalConfigurationModel()
        {
            ServiceDiscoveryProvider = new ServiceDiscoveryProviderDto();
            RateLimitOptions = new RateLimitOptionsDto();
            QoSOptions = new QosOptionsDto();
            LoadBalancerOptions = new LoadBalancerOptionsDto();
            HttpHandlerOptions = new HttpHandlerOptionsDto();
        }
    }
}
