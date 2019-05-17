using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class CacheOptions : Entity<int>
    {
        public virtual int ReRouteId { get; private set; }
        public virtual int TtlSeconds { get; private set; }
        public virtual string Region { get; private set; }

        protected CacheOptions()
        {

        }
        public CacheOptions(int rerouteId)
        {
            ReRouteId = rerouteId;
        }

        public void SetCacheOption(int ttl, string region)
        {
            TtlSeconds = ttl;
            Region = region;
        }
    }
}
