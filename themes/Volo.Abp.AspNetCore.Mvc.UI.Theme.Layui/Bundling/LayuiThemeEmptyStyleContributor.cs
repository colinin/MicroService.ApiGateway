using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.FontAwesome;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Toastr;
using Volo.Abp.Modularity;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui.Bundling
{
    [DependsOn(
       typeof(BootstrapStyleContributor),
       typeof(FontAwesomeStyleContributor),
       typeof(ToastrStyleBundleContributor)
        )]
    public class LayuiThemeEmptyStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/lib/layui/css/layui.css");
        }
    }
}
