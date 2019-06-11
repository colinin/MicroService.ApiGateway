using System;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class CacheOptionsDto
    {
        public int? TtlSeconds { get; set; }
        public string Region { get; set; }
    }
}
