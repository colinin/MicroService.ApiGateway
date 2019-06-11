using System;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class AggregateReRouteConfigDto
    {
        public string ReRouteKey { get; set; }
        public string Parameter { get; set; }
        public string JsonPath { get; set; }
    }
}
