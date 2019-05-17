using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui
{
    [ThemeName(Name)]
    public class LayuiTheme : ITheme, ITransientDependency
    {
        public const string Name = "Layui";

        public string GetLayout(string name, bool fallbackToDefault = true)
        {
            switch (name)
            {
                case StandardLayouts.Application:
                    return "~/Themes/Layui/Layouts/Application.cshtml";
                case StandardLayouts.Account:
                    return "~/Themes/Layui/Layouts/Account.cshtml";
                case StandardLayouts.Empty:
                    return "~/Themes/Layui/Layouts/Empty.cshtml";
                default:
                    return fallbackToDefault ? "~/Themes/Layui/Layouts/Application.cshtml" : null;
            }
        }
    }
}
