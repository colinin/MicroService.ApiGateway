using DotNetCore.CAP.Infrastructure;
using Volo.Abp.DependencyInjection;

namespace MicroService.ApiGateway.Snowflake
{
    public class CAPSnowflakeIdGenerator : ISnowflakeIdGenerator, ISingletonDependency
    {
        private readonly SnowflakeId _snowflakeId;
        public CAPSnowflakeIdGenerator()
        {
            _snowflakeId = SnowflakeId.Default();
        }

        public long NextId()
        {
            return _snowflakeId.NextId();
        }
    }
}
