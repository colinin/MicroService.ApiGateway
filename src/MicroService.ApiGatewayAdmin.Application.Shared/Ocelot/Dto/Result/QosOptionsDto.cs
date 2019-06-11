using System;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class QosOptionsDto
    {
        public int? ExceptionsAllowedBeforeBreaking { get; set; }

        public int? DurationOfBreak { get; set; }

        public int? TimeoutValue { get; set; }
    }
}
