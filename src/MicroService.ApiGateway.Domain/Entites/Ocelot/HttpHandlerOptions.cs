using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class HttpHandlerOptions : Entity<int>
    {
        public virtual long ItemId { get; private set; }

        public virtual bool AllowAutoRedirect { get; private set; }

        public virtual bool UseCookieContainer { get; private set; }

        public virtual bool UseTracing { get; private set; }

        public virtual bool UseProxy { get; private set; }

        protected HttpHandlerOptions()
        {

        }

        public HttpHandlerOptions(long itemId)
        {
            ItemId = itemId;
        }

        public void ApplyAllowAutoRedirect(bool allowAutoRedirect)
        {
            AllowAutoRedirect = allowAutoRedirect;
        }
        public void ApplyCookieContainer(bool useCookieContainer)
        {
            UseCookieContainer = useCookieContainer;
        }

        public void ApplyHttpTracing(bool httpTracing)
        {
            UseTracing = httpTracing;
        }

        public void ApplyHttpProxy(bool httpProxy)
        {
            UseProxy = httpProxy;
        }
    }
}
