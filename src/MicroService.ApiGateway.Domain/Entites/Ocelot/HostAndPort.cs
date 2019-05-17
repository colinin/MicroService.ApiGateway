using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class HostAndPort : Entity<int>
    {
        public virtual int ReRouteId { get; private set; }
        public virtual string Host { get; private set; }
        public virtual int Port { get; private set; }

        protected HostAndPort()
        {

        }

        public HostAndPort(int rerouteId)
        {
            ReRouteId = rerouteId;
        }

        public void SetHostAndPort(string host, int port)
        {
            Host = host;
            Port = port;
        }
    }
}
