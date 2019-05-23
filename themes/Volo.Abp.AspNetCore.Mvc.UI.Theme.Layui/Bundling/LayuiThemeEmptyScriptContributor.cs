using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.JQueryValidationUnobtrusive;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.SweetAlert;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Toastr;
using Volo.Abp.Modularity;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui.Bundling
{
    [DependsOn(
        typeof(BootstrapScriptContributor),
        typeof(JQueryValidationUnobtrusiveScriptContributor),
        typeof(SweetalertScriptContributor),
        typeof(ToastrScriptBundleContributor))]
    public class LayuiThemeEmptyScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddRange(new[]
            {
                "/libs/abp/aspnetcore-mvc-ui-theme-shared/bootstrap/dom-event-handlers.js",
                "/libs/abp/aspnetcore-mvc-ui-theme-shared/bootstrap/modal-manager.js",
                "/libs/abp/aspnetcore-mvc-ui-theme-shared/sweetalert/abp-sweetalert.js",
                "/libs/abp/aspnetcore-mvc-ui-theme-shared/toastr/abp-toastr.js"
            });
        }
    }
}
