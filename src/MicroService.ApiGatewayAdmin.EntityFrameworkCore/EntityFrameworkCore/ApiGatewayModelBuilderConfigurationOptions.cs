using JetBrains.Annotations;
using MicroService.ApiGateway.Settings;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MicroService.ApiGateway.EntityFrameworkCore
{
    public class ApiGatewayModelBuilderConfigurationOptions : ModelBuilderConfigurationOptions
    {
        public ApiGatewayModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = ApiGatewaySettings.DefaultDbTablePrefix,
            [CanBeNull] string schema = ApiGatewaySettings.DefaultDbSchema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}
