using Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui.Themes.Layui;
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
                case LayuiLayouts.Application:
                    return "~/Themes/Layui/Layouts/Empty.cshtml";
                case LayuiLayouts.Main:
                    return "~/Themes/Layui/Layouts/Application.cshtml";
                default:
                    return fallbackToDefault ? "~/Themes/Layui/Layouts/Empty.cshtml" : null;
            }
        }
    }
}
