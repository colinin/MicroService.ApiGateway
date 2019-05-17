namespace MicroService.ApiGateway.Ocelot.Dto
{
    public class CacheOptionsDto
    {
        public int TtlSeconds { get; set; }
        public string Region { get; set; }
    }
}
