using Newtonsoft.Json;
using Volo.Abp.MicroService.Json.Newtonsoft;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    public class ReRouteDto
    {
        public int Id { get; set; }
        
        /// <remarks>
        /// 类型 <see cref="AbpHexLongConverter"/> 为自定义的
        /// Json格式转换器,它避免了JavaScript与C#对于Long数据
        /// 类型的序列化数据精度丢失问题,自己实现一个就行了
        /// </remarks>
        [JsonConverter(typeof(AbpHexLongConverter))]
        public long ReRouteId { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string ReRouteName { get; set; }
        public string DownstreamPathTemplate { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public string UpstreamHttpMethod { get; set; }
        public string AddHeadersToRequest { get; set; }
        public string UpstreamHeaderTransform { get; set; }
        public string DownstreamHeaderTransform { get; set; }
        public string AddClaimsToRequest { get; set; }
        public string RouteClaimsRequirement { get; set; }
        public string AddQueriesToRequest { get; set; }
        public string RequestIdKey { get; set; }
        public CacheOptionsDto FileCacheOptions { get; set; }
        public bool ReRouteIsCaseSensitive { get; set; }
        public string ServiceName { get; set; }
        public string DownstreamScheme { get; set; }
        public QosOptionsDto QoSOptions { get; set; }
        public LoadBalancerOptionsDto LoadBalancerOptions { get; set; }
        public RateLimitRuleDto RateLimitOptions { get; set; }
        public AuthenticationOptionsDto AuthenticationOptions { get; set; }
        public HttpHandlerOptionsDto HttpHandlerOptions { get; set; }
        public string DownstreamHostAndPorts { get; set; }
        public string UpstreamHost { get; set; }
        public string Key { get; set; }
        public string DelegatingHandlers { get; set; }
        public int? Priority { get; set; }
        public int? Timeout { get; set; }
        public bool DangerousAcceptAnyServerCertificateValidator { get; set; }
        public SecurityOptionsDto SecurityOptions { get; set; }

        public ReRouteDto()
        {
            FileCacheOptions = new CacheOptionsDto();
            QoSOptions = new QosOptionsDto();
            LoadBalancerOptions = new LoadBalancerOptionsDto();
            RateLimitOptions = new RateLimitRuleDto();
            AuthenticationOptions = new AuthenticationOptionsDto();
            HttpHandlerOptions = new HttpHandlerOptionsDto();
            SecurityOptions = new SecurityOptionsDto();
        }
    }
}
