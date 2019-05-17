using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Startui
{
    [ThemeName(Name)]
    public class StartuiTheme : ITheme, ITransientDependency
    {
        public const string Name = "Startui";

        public string GetLayout(string name, bool fallbackToDefault = true)
        {
            switch (name)
            {
                case StandardLayouts.Application:
                    return "~/Themes/Startui/Layouts/Application.cshtml";
                case StandardLayouts.Account:
                    return "~/Themes/Startui/Layouts/Account.cshtml";
                case StandardLayouts.Empty:
                    return "~/Themes/Startui/Layouts/Empty.cshtml";
                default:
                    return fallbackToDefault ? "~/Themes/Startui/Layouts/Application.cshtml" : null;
            }
        }
    }
}
