using System;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class HttpHandlerOptionsDto
    {
        public bool AllowAutoRedirect { get; set; }

        public bool UseCookieContainer { get; set; }

        public bool UseTracing { get; set; }

        public bool UseProxy { get; set; }
    }
}