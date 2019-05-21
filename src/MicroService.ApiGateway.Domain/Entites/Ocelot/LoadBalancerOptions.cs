using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class LoadBalancerOptions : Entity<int>
    {
        public virtual long ItemId { get; private set; }
        public virtual string Type { get; private set; }
        public virtual string Key { get; private set; }
        public virtual int? Expiry { get; private set; }

        protected LoadBalancerOptions()
        {

        }
        public LoadBalancerOptions(long itemId)
        {
            ItemId = itemId;
        }

        public void SetLoadBalancerOptions(string type, string key, int? expiry)
        {
            Type = type;
            Key = key;
            Expiry = expiry;
        }
    }
}
