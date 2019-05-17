using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Uplon.Themes.Uplon.Components.Toolbar.UserMenu
{
    public class UserMenuViewComponent : AbpViewComponent
    {
        private readonly IMenuManager _menuManager;

        public UserMenuViewComponent(IMenuManager menuManager)
        {
            _menuManager = menuManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = await _menuManager.GetAsync(StandardMenus.User);
            return View("~/Themes/Uplon/Components/Toolbar/UserMenu/Default.cshtml", menu);
        }
    }
}
