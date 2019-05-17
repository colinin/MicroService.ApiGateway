using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui.Bundling
{
    public class LayuiThemeGlobalScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/lib/layui/layui.js");
            context.Files.Add("/js/cache.js");
            context.Files.Add("/js/layout.js");
        }
    }
}
