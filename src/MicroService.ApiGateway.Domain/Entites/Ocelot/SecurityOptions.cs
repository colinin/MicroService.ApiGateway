using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class SecurityOptions : Entity<int>
    {
        public virtual long ReRouteId { get; private set; }

        public virtual string IPAllowedList { get; private set; }

        public virtual string IPBlockedList { get; private set; }

        protected SecurityOptions()
        {

        }
        public SecurityOptions(long rerouteId)
        {
            ReRouteId = rerouteId;
        }
        public void AddAllowIpList(params string[] allowIpList)
        {
            foreach(var ip in allowIpList)
            {
                IPAllowedList += ip + ";" ;
            }
        }

        public void AddBlockIpList(params string[] blockIpList)
        {
            foreach (var ip in blockIpList)
            {
                IPBlockedList += ip + ";";
            }
        }
    }
}
