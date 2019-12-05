using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class DynamicReRoute : AggregateRoot<int>
    {
        public virtual long DynamicReRouteId { get; private set; }
        public virtual string ServiceName { get; private set; }
        public virtual RateLimitRule RateLimitRule { get; private set; }
        protected DynamicReRoute()
        {

        }
        public DynamicReRoute(long dynamicReRouteId, string serviceName)
        {
            DynamicReRouteId = dynamicReRouteId;
            ServiceName = serviceName;
            RateLimitRule = new RateLimitRule("", null, null);
            RateLimitRule.SetDynamicReRouteId(DynamicReRouteId);
        }

        public void SetRateLimitRule(RateLimitRule limitRule)
        {
            RateLimitRule = limitRule;
        }
    }
}
