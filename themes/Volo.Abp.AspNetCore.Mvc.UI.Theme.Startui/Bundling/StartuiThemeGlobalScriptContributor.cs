using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Startui.Bundling
{
    public class StartuiThemeGlobalScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/themes/startui/startui.js");
            context.Files.Add("/themes/startui/extensions.js");
        }
    }
}
