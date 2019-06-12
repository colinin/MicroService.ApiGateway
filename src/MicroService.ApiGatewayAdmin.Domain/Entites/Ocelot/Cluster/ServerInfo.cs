using JetBrains.Annotations;
using MicroService.ApiGatewayAdmin.Ocelot.Cluster;
using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGatewayAdmin.Entites.Ocelot.Cluster
{
    public class ServerInfo : AggregateRoot<int>
    {
        public virtual long ServerId { get; private set; }
        public virtual string ServerName { get; protected set; }
        public virtual string Description { get; set; }
        public virtual string Host { get; protected set; }
        public virtual int Port { get; protected set; }
        public virtual string EventName { get; protected set; }
        public virtual ServceConfigType ConfigType { get; protected set; }
        public virtual ServerAuth ServerAuth { get; protected set; }

        public ServerInfo(long serverId, [NotNull] string serverName)
        {
            ServerId = serverId;
            ServerName = serverName;
            InitlizaServer();
            ChangeType();
        }

        public void ChangeType(ServceConfigType configType = ServceConfigType.DataBase)
        {
            ConfigType = configType;
        }

        public void BindServer([NotNull] string host, int port = 80)
        {
            Host = host;
            Port = port;
        }

        public void RegisterEvent([NotNull] string eventName)
        {
            EventName = eventName;
        }

        private void InitlizaServer()
        {
            ServerAuth = new ServerAuth(ServerId);
        }
    }
}
