using System;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class DynamicReRouteModel
    {
        public string ServiceName { get; set; }
        public RateLimitRuleDto RateLimitRule { get; set; }

        public DynamicReRouteModel()
        {
            RateLimitRule = new RateLimitRuleDto();
        }
    }
}
