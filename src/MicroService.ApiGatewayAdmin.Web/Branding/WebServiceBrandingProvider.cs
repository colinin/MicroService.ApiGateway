using MicroService.ApiGatewayAdmin.Domain.Localization.ApiGateway;
using Microsoft.Extensions.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace MicroService.ApiGateway.Branding
{
    [Dependency(ReplaceServices = true)]
    public class WebServiceBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => _stringLocalizer["OcelotManager"];

        public override string LogoUrl => "/favicon.png";

        private readonly IStringLocalizer<ApiGatewayResource> _stringLocalizer;

        public WebServiceBrandingProvider(IStringLocalizer<ApiGatewayResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
    }
}
