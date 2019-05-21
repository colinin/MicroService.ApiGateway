namespace MicroService.ApiGateway.Ocelot.Dto
{
    public class DynamicReRouteDto
    {
        public string ServiceName { get; set; }
        public RateLimitRuleDto RateLimitRule { get; set; }
    }
}
