using Newtonsoft.Json;
using System;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class AggregateReRouteDto : AggregateReRouteDtoBase
    {
        [JsonConverter(typeof(HexLongConverter))]
        public long ReRouteId { get; set; }

        public AggregateReRouteDto()
        {
        }
    }
}
