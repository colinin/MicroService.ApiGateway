using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Uplon
{
    [ThemeName(Name)]
    public class UplonTheme : ITheme, ITransientDependency
    {
        public const string Name = "Uplon";

        public string GetLayout(string name, bool fallbackToDefault = true)
        {
            switch (name)
            {
                case StandardLayouts.Application:
                    return "~/Themes/Uplon/Layouts/Application.cshtml";
                case StandardLayouts.Account:
                    return "~/Themes/Uplon/Layouts/Account.cshtml";
                case StandardLayouts.Empty:
                    return "~/Themes/Uplon/Layouts/Empty.cshtml";
                default:
                    return fallbackToDefault ? "~/Themes/Uplon/Layouts/Application.cshtml" : null;
            }
        }
    }
}
