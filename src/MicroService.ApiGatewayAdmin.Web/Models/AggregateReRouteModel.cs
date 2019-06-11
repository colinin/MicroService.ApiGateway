using System;
using System.Collections.Generic;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class AggregateReRouteModel
    {
        public List<string> ReRouteKeys { get; set; }
        public List<AggregateReRouteConfigDto> ReRouteKeysConfig { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public string UpstreamHost { get; set; }
        public bool ReRouteIsCaseSensitive { get; set; }
        public string Aggregator { get; set; }
        public int Priority { get; set; }

        public AggregateReRouteModel()
        {
            ReRouteKeys = new List<string>();
            ReRouteKeysConfig = new List<AggregateReRouteConfigDto>();
        }
    }
}
