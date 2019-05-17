using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Uplon.Bundling
{
    public class UplonThemeGlobalStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            //context.Files.ReplaceOne("/libs/font-awesome/css/font-awesome.css", "/css/font-awesome/font-awesome.css");
            context.Files.Remove("/libs/font-awesome/css/font-awesome.css");

            context.Files.Add("/css/layout.css");
        }
    }
}
