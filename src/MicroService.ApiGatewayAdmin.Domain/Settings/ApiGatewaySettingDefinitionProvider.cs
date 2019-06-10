using Volo.Abp.Settings;

namespace MicroService.ApiGateway.Settings
{
    public class ApiGatewaySettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(MicroService.ApiGatewaySettings.MySetting1));
        }
    }
}
