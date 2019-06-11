using System;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class DynamicReRouteDtoBase
    {
        public string ServiceName { get; set; }
        public RateLimitRuleDto RateLimitRule { get; set; }

        public DynamicReRouteDtoBase()
        {
            RateLimitRule = new RateLimitRuleDto();
        }
    }
}
