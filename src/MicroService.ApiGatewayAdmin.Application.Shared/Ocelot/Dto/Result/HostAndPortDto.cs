using System;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class HostAndPortDto
    {
        public string Host { get; set; }
        public int? Port { get; set; }
    }
}