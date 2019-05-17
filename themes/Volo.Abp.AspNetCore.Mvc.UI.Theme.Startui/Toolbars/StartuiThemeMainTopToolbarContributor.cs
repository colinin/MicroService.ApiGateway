using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Startui.Themes.Startui.Components.Toolbar.LanguageSwitch;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Startui.Themes.Startui.Components.Toolbar.UserMenu;
using Volo.Abp.Localization;
using Volo.Abp.Users;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Startui.Toolbars
{
    public class StartuiThemeMainTopToolbarContributor : IToolbarContributor
    {
        public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name != StandardToolbars.Main)
            {
                return Task.CompletedTask;
            }

            if (!(context.Theme is StartuiTheme))
            {
                return Task.CompletedTask;
            }

            var languageProvider = context.ServiceProvider.GetService<ILanguageProvider>();

            //TODO: This duplicates GetLanguages() usage. Can we eleminate this?
            if (languageProvider.GetLanguages().Count > 1)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitchViewComponent), 0));
            }

            if (context.ServiceProvider.GetRequiredService<ICurrentUser>().IsAuthenticated)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(UserMenuViewComponent), 1));
            }

            return Task.CompletedTask;
        }
    }
}
