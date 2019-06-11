using Newtonsoft.Json;
using System;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class ReRouteDto : ReRouteDtoBase
    {
        public int Id { get; set; }
        
        [JsonConverter(typeof(HexLongConverter))]
        public long ReRouteId { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string ReRouteName { get; set; }
        public ReRouteDto()
        {
        }
    }
}
