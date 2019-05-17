using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class ServiceDiscoveryProvider : Entity<int>
    {
        public virtual int ItemId { get; protected set; }
        public virtual string Host { get; set; }
        public virtual int Port { get; set; }
        public virtual string Type { get; set; }
        public virtual string Token { get; set; }
        public virtual string ConfigurationKey { get; set; }
        public virtual int PollingInterval { get; set; }
        public virtual string Namespace { get; set; }

        protected ServiceDiscoveryProvider()
        {

        }
        public ServiceDiscoveryProvider(int itemId)
        {
            ItemId = itemId;
        }
    }
}
