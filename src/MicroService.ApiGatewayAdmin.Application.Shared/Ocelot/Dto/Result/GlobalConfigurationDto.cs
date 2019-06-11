using Newtonsoft.Json;
using System;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class GlobalConfigurationDto : GlobalConfigurationDtoBase
    {
        [JsonConverter(typeof(HexLongConverter))]
        public long ItemId { get;  set; }
        public GlobalConfigurationDto()
        {
        }
    }
}
