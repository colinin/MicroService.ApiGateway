namespace MicroService.ApiGateway.Ocelot.Dto
{
    public class ReRouteCreateDto
    {
        public int ReRouteId { get; set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        public string ReRouteName { get; set; }
        /// <summary>
        /// 下游路由路径
        /// </summary>
        public string DownstreamPathTemplate { get; set; }
        /// <summary>
        /// 上游路由路径
        /// </summary>
        public string UpstreamPathTemplate { get; set; }
        /// <summary>
        /// 下游Http方法列表,分号间隔
        /// </summary>
        public string UpstreamHttpMethod { get; set; }
        /// <summary>
        /// 下游请求头
        /// </summary>
        public string AddHeadersToRequest { get; set; }
        /// <summary>
        /// 上游请求头变更
        /// </summary>
        public string UpstreamHeaderTransform { get; set; }
        /// <summary>
        /// 下游请求头变更
        /// </summary>
        public string DownstreamHeaderTransform { get; set; }
        /// <summary>
        /// 添加请求令牌
        /// </summary>
        public string AddClaimsToRequest { get; set; }
        public string RouteClaimsRequirement { get; set; }
        /// <summary>
        /// 添加请求参数
        /// </summary>
        public string AddQueriesToRequest { get; set; }
        public string RequestIdKey { get; set; }
        public CacheOptionsDto CacheOptions { get; set; }
        public bool? ReRouteIsCaseSensitive { get; set; }
        public string ServiceName { get; set; }
        public string DownstreamScheme { get; set; }
        public QosOptionsDto QoSOptions { get; set; }
        public LoadBalancerOptionsDto LoadBalancerOptions { get; set; }
        public RateLimitRuleDto RateLimitOptions { get; set; }
        public AuthenticationOptionsDto AuthenticationOptions { get; set; }
        public HttpHandlerOptionsDto HttpHandlerOptions { get; set; }
        public string DownstreamHostAndPorts { get; set; }
        public string DelegatingHandlers { get; set; }
        public string UpstreamHost { get; set; }
        public string Key { get; set; }
        public int? Priority { get; set; }
        public int? Timeout { get; set; }
        public bool? DangerousAcceptAnyServerCertificateValidator { get; set; }
        public SecurityOptionsDto SecurityOptions { get; set; }
    }
}
