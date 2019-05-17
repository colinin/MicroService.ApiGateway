using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui.Bundling
{
    public class LayuiThemeGlobalStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/lib/layui/css/layui.css");
            context.Files.Add("/css/layout.css");
        }
    }
}
