using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace MicroService.ApiGateway.Branding
{
    [Dependency(ReplaceServices = true)]
    public class WebServiceBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "微服务平台";

        public override string LogoUrl => "/favicon.png";
    }
}
