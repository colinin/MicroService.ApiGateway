using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class AuthenticationOptions : Entity<int>
    {
        public virtual int ReRouteId { get; private set; }
        public virtual string AuthenticationProviderKey { get; private set; }
        public virtual string AllowedScopes { get; set; }

        protected AuthenticationOptions()
        {

        }
        public AuthenticationOptions(int rerouteId)
        {
            ReRouteId = rerouteId;
        }

        public void SetOptions(string key, params string[] allowScopes)
        {
            AuthenticationProviderKey = key;
            AddAllowScopes(allowScopes);
        }

        public void AddAllowScopes(params string[] allowScopes)
        {
            foreach (var scope in allowScopes)
            {
                AuthenticationProviderKey += scope + ";";
            }
        }
    }
}
