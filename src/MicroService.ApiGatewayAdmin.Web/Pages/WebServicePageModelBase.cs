using MicroService.ApiGatewayAdmin.Domain.Localization.ApiGateway;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MicroService.ApiGateway.Pages
{
    public abstract class WebServicePageModelBase : AbpPageModel
    {
        protected WebServicePageModelBase()
        {
            LocalizationResourceType = typeof(ApiGatewayResource);
        }
    }
}