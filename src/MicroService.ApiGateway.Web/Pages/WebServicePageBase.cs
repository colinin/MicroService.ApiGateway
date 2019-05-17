using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using MicroService.ApiGateway.Localization.MicroService.ApiGateway;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MicroService.ApiGateway.Pages
{
    public abstract class WebServicePageBase : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<ApiGatewayResource> L { get; set; }
    }
}
