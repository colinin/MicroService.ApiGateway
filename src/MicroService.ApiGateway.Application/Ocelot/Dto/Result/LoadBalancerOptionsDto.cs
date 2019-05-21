namespace MicroService.ApiGateway.Ocelot.Dto
{
    public class LoadBalancerOptionsDto
    {
        public string Type { get; set; }
        public string Key { get; set; }
        public int? Expiry { get; set; }
    }
}