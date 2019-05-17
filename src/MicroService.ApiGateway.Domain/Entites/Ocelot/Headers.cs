using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class Headers : Entity<int>
    {
        public virtual int ReRouteId { get; private set; }
        public virtual string Key { get; private set; }
        public virtual string Value { get; private set; }

        protected Headers()
        {

        }
        public Headers(int rerouteId)
        {
            ReRouteId = rerouteId;
        }

        public void SetHeader(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
