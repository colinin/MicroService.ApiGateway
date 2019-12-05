using Volo.Abp.Domain.Entities;

namespace MicroService.ApiGateway.Entites.Ocelot
{
    public class ReRoute : AggregateRoot<int>
    {
        /// <summary>
        /// 路由ID
        /// </summary>
        public virtual long ReRouteId { get; protected set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        public virtual string ReRouteName { get; protected set; }
        /// <summary>
        /// 下游路由路径
        /// </summary>
        public virtual string DownstreamPathTemplate { get; protected set; }
        /// <summary>
        /// 上游路由路径
        /// </summary>
        public virtual string UpstreamPathTemplate { get; protected set; }
        /// <summary>
        /// 下游Http方法列表,分号间隔
        /// </summary>
        public virtual string UpstreamHttpMethod { get; protected set; }
        public virtual string AddHeadersToRequest { get; protected set; }
        public virtual string UpstreamHeaderTransform { get; protected set; }
        public virtual string DownstreamHeaderTransform { get; protected set; }
        public virtual string AddClaimsToRequest { get; protected set; }
        public virtual string RouteClaimsRequirement { get; protected set; }
        public virtual string AddQueriesToRequest { get; protected set; }
        public virtual string RequestIdKey { get; set; }
        public virtual CacheOptions CacheOptions { get; protected set; }
        public virtual bool ReRouteIsCaseSensitive { get; set; }
        public virtual string ServiceName { get; set; }
        public virtual string DownstreamScheme { get; set; }
        public virtual QoSOptions QoSOptions { get; protected set; }
        public virtual LoadBalancerOptions LoadBalancerOptions { get; protected set; }
        public virtual RateLimitRule RateLimitOptions { get; protected set; }
        public virtual AuthenticationOptions AuthenticationOptions { get; protected set; }
        public virtual HttpHandlerOptions HttpHandlerOptions { get; protected set; }
        public virtual string DownstreamHostAndPorts { get; protected set; }
        public virtual string DelegatingHandlers { get; set; }
        public virtual string UpstreamHost { get; set; }
        public virtual string Key { get; set; }
        public virtual int? Priority { get; set; }
        public virtual int? Timeout { get; set; }
        public virtual bool DangerousAcceptAnyServerCertificateValidator { get; set; }
        public virtual SecurityOptions SecurityOptions { get; protected set; }

        protected ReRoute()
        {

        }

        public ReRoute(long rerouteId, string routeName, string downPath, string upPath, string upMethod, string downHost)
        {
            ReRouteId = rerouteId;
            ModifyRouteInfo(routeName, downPath, upPath, upMethod, downHost);
            InitlizaReRoute();
        }

        public void ModifyRouteInfo(string routeName, string downPath, string upPath, string upMethod, string downHost)
        {
            ReRouteName = routeName;
            DownstreamPathTemplate = downPath;
            UpstreamPathTemplate = upPath;
            UpstreamHttpMethod = upMethod;
            DownstreamHostAndPorts = downHost;
        }

        public void SetQueriesParamter(string value)
        {
            AddQueriesToRequest = value;
        }

        public void SetRouteClaims(string value)
        {
            RouteClaimsRequirement = value;
        }

        public void SetRequestClaims(string value)
        {
            AddClaimsToRequest = value;
        }

        public void SetDownstreamHeader(string value)
        {
            DownstreamHeaderTransform = value;
        }

        public void SetUpstreamHeader(string value)
        {
            UpstreamHeaderTransform = value;
        }

        public void SetRequestHeader(string value)
        {
            AddHeadersToRequest = value;
        }

        private void InitlizaReRoute()
        {
            QoSOptions = new QoSOptions(null, null, 30000);
            QoSOptions.SetReRouteId(ReRouteId);
            CacheOptions = new CacheOptions(ReRouteId);
            LoadBalancerOptions = new LoadBalancerOptions("LeastConnection", "SessionId", null);
            LoadBalancerOptions.SetReRouteId(ReRouteId);
            RateLimitOptions = new RateLimitRule("", null, null);
            RateLimitOptions.SetReRouteId(ReRouteId);
            AuthenticationOptions = new AuthenticationOptions(ReRouteId);
            HttpHandlerOptions = HttpHandlerOptions.Default();
            HttpHandlerOptions.SetReRouteId(ReRouteId);
            SecurityOptions = new SecurityOptions(ReRouteId);
        }
    }
}
