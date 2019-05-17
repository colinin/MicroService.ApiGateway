using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class HttpHandlerOptions : Entity<int>
    {
        public virtual int ItemId { get; private set; }

        public virtual bool AllowAutoRedirect { get; private set; }

        public virtual bool UseCookieContainer { get; private set; }

        public virtual bool UseTracing { get; private set; }

        public virtual bool UseProxy { get; private set; }

        protected HttpHandlerOptions()
        {

        }

        public HttpHandlerOptions(int itemId)
        {
            ItemId = itemId;
        }

        public void EnableAllowAutoRedirect()
        {
            AllowAutoRedirect = true;
        }

        public void DisableAllowAutoRedirect()
        {
            AllowAutoRedirect = false;
        }

        public void EnableCookieContainer()
        {
            UseCookieContainer = true;
        }

        public void DisableCookieContainer()
        {
            UseCookieContainer = false;
        }

        public void EnableTracing()
        {
            UseTracing = true;
        }

        public void DisableTracing()
        {
            UseTracing = false;
        }

        public void EnableProxy()
        {
            UseProxy = true;
        }

        public void DisableProxy()
        {
            UseProxy = false;
        }
    }
}
