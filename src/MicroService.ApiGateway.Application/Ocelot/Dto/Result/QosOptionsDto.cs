namespace MicroService.ApiGateway.Ocelot.Dto
{
    public class QosOptionsDto
    {
        public int? ExceptionsAllowedBeforeBreaking { get; set; }

        public int? DurationOfBreak { get; set; }

        public int? TimeoutValue { get; set; }
    }
}
