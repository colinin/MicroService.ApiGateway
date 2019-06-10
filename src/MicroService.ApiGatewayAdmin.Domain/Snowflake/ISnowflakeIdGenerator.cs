namespace MicroService.ApiGateway.Snowflake
{
    public interface ISnowflakeIdGenerator
    {
        long NextId();
    }
}
