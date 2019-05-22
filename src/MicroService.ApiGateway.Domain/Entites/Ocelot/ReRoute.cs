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
        /// <summary>
        /// 下游请求头
        /// </summary>
        public virtual string AddHeadersToRequest { get; protected set; }
        /// <summary>
        /// 上游请求头变更
        /// </summary>
        public virtual string UpstreamHeaderTransform { get; protected set; }
        /// <summary>
        /// 下游请求头变更
        /// </summary>
        public virtual string DownstreamHeaderTransform { get; protected set; }
        /// <summary>
        /// 添加请求令牌
        /// </summary>
        public virtual string AddClaimsToRequest { get; protected set; }
        public virtual string RouteClaimsRequirement { get; protected set; }
        /// <summary>
        /// 添加请求参数
        /// </summary>
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

        public ReRoute(long rerouteId, string routeName, string downPath, string upPath, string upMethod)
        {
            ReRouteId = rerouteId;
            ModifyRouteInfo(routeName, downPath, upPath, upMethod);
            InitlizaReRoute();
        }

        public void ModifyRouteInfo(string routeName, string downPath, string upPath, string upMethod)
        {
            ReRouteName = routeName;
            DownstreamPathTemplate = downPath;
            UpstreamPathTemplate = upPath;
            UpstreamHttpMethod = upMethod;
        }

        public void AddRequestHeader(Headers headers)
        {
            AddHeadersToRequest += $"{headers.Key}:{headers.Value};";
        }

        public void AddUpStreamHeader(Headers headers)
        {
            UpstreamHeaderTransform += $"{headers.Key}:{headers.Value};";
        }

        public void AddDownStreamHeader(Headers headers)
        {
            DownstreamHeaderTransform += $"{headers.Key}:{headers.Value};";
        }

        public void AddRequestClaim(Headers headers)
        {
            AddClaimsToRequest += $"{headers.Key}:{headers.Value};";
        }

        public void AddRequirementCalim(Headers headers)
        {
            RouteClaimsRequirement += $"{headers.Key}:{headers.Value};";
        }

        public void AddRequestQueries(Headers headers)
        {
            AddQueriesToRequest += $"{headers.Key}:{headers.Value};";
        }

        public void AddDownStreamHostAndPort(HostAndPort hostAndPort)
        {
            DownstreamHostAndPorts += $"{hostAndPort.Host}:{hostAndPort.Port};";
        }
        
        private void InitlizaReRoute()
        {
            QoSOptions = new QoSOptions(ReRouteId);
            CacheOptions = new CacheOptions(ReRouteId);
            LoadBalancerOptions = new LoadBalancerOptions(ReRouteId);
            RateLimitOptions = new RateLimitRule(ReRouteId);
            AuthenticationOptions = new AuthenticationOptions(ReRouteId);
            HttpHandlerOptions = new HttpHandlerOptions(ReRouteId);
            SecurityOptions = new SecurityOptions(ReRouteId);
        }
    }
}
