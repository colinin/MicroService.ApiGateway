using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Uplon.Bundling
{
    public class UplonThemeGlobalScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/js/layout-core.js");
            context.Files.Add("/js/layout-app.js");
            context.Files.Add("/js/fastclick.js");
            context.Files.Add("/js/detect.js");
            context.Files.Add("/js/slimscroll.js");
        }
    }
}
