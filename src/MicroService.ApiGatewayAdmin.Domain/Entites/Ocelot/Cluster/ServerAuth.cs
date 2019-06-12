using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGatewayAdmin.Entites.Ocelot.Cluster
{
    public class ServerAuth : Entity<int>
    {
        public virtual long ServerId { get; private set; }
        public virtual string ApiAddress { get; private set; }
        public virtual string ClientId { get; private set; }
        public virtual string ClientSecret { get; private set; }
        public virtual string Scope { get; private set; }
        public virtual string GrantType { get; private set; }

        protected ServerAuth() { }

        public ServerAuth(long serverId)
        {
            ServerId = serverId;
        }

        public void ApplyAuthorize([NotNull] string apiAddress, [NotNull] string clientId, [NotNull] string clientSecret, string scope = "admin", string grantType = "client_credentials")
        {
            ApiAddress = apiAddress;
            ClientId = clientId;
            ClientSecret = clientSecret;
            Scope = scope;
            GrantType = grantType;
        }
    }
}
