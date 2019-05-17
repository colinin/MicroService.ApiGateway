using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class RateLimitOptions : Entity<int>
    {
        public virtual int ItemId { get; protected set; }
        public virtual string ClientIdHeader { get; set; }
        public virtual string QuotaExceededMessage { get; set; }
        public virtual string RateLimitCounterPrefix { get; set; }
        public virtual bool DisableRateLimitHeaders { get; set; }
        public virtual int HttpStatusCode { get; set; }

        protected RateLimitOptions()
        {

        }

        public RateLimitOptions(int itemId)
        {
            ItemId = itemId;
            Initl();
        }

        private void Initl()
        {
            ClientIdHeader = "ClientId";
            RateLimitCounterPrefix = "ocelot";
            HttpStatusCode = 429;
        }
    }
}
