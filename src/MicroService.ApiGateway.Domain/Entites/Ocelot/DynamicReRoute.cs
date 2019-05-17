using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class DynamicReRoute : AggregateRoot<int>
    {
        public virtual int DunamicReRouteId { get; private set; }
        public virtual string ServiceName { get; private set; }
        public virtual RateLimitRule RateLimitRule { get; private set; }
        protected DynamicReRoute()
        {

        }
        public DynamicReRoute(int dynamicReRouteId, string serviceName)
        {
            DunamicReRouteId = dynamicReRouteId;
            ServiceName = serviceName;
            RateLimitRule = new RateLimitRule(DunamicReRouteId);
        }

        public void SetRateLimitRule(RateLimitRule limitRule)
        {
            RateLimitRule = limitRule;
        }
    }
}
