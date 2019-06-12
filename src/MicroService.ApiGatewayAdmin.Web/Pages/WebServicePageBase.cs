using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using MicroService.ApiGatewayAdmin.Domain.Localization.ApiGateway;

namespace MicroService.ApiGateway.Pages
{
    public abstract class WebServicePageBase : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<ApiGatewayResource> L { get; set; }
    }
}
