using MicroService.ApiGateway.Data.Filter;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class GlobalConfiguration : AggregateRoot<int>, ISoftDelete, IActivation
    {
        public virtual long ItemId { get; protected set; }
        public virtual string RequestIdKey { get; set; }
        public virtual ServiceDiscoveryProvider ServiceDiscoveryProvider { get; protected set; }

        public virtual RateLimitOptions RateLimitOptions { get; protected set; }

        public virtual QoSOptions QoSOptions { get; protected set; }

        public virtual string BaseUrl { get; set; }

        public virtual LoadBalancerOptions LoadBalancerOptions { get; protected set; }

        public virtual string DownstreamScheme { get; set; }

        public virtual HttpHandlerOptions HttpHandlerOptions { get; protected set; }

        public bool IsDeleted { get ; set ; }
        public bool IsActive { get; set; }

        protected GlobalConfiguration()
        {

        }

        public GlobalConfiguration(long itemId, string baseUrl)
        {
            ItemId = itemId;
            BaseUrl = baseUrl;
            Init();
        }

        private void Init()
        {
            ServiceDiscoveryProvider = new ServiceDiscoveryProvider(ItemId);
            RateLimitOptions = new RateLimitOptions(ItemId);
            QoSOptions = new QoSOptions(ItemId);
            LoadBalancerOptions = new LoadBalancerOptions(ItemId);
            HttpHandlerOptions = new HttpHandlerOptions(ItemId);
            IsActive = true;
            IsDeleted = false;
        }
    }
}
