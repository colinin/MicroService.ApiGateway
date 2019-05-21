using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class RateLimitOptions : Entity<int>
    {
        public virtual long ItemId { get; protected set; }
        public virtual string ClientIdHeader { get; set; }
        public virtual string QuotaExceededMessage { get; set; }
        public virtual string RateLimitCounterPrefix { get; set; }
        public virtual bool DisableRateLimitHeaders { get; set; }
        public virtual int? HttpStatusCode { get; set; }

        protected RateLimitOptions()
        {

        }

        public RateLimitOptions(long itemId)
        {
            ItemId = itemId;
            Initl();
        }

        public void SetRateLimitOptions(string clientHeader, string excepMessage, int? httpStatusCode = 429)
        {
            DisableRateLimitHeaders = true;
            ClientIdHeader = clientHeader;
            QuotaExceededMessage = excepMessage;
            HttpStatusCode = httpStatusCode;
        }

        private void Initl()
        {
            ClientIdHeader = "ClientId";
            RateLimitCounterPrefix = "ocelot";
            HttpStatusCode = 429;
        }
    }
}
