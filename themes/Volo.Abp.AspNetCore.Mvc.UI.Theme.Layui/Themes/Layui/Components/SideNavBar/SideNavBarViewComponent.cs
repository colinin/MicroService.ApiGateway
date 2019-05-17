using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui.Themes.Layui.Components.SideNavBar
{
    public class SideNavBarViewComponent : AbpViewComponent
    {
        private readonly IMenuManager _menuManager;

        public SideNavBarViewComponent(IMenuManager menuManager)
        {
            _menuManager = menuManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sideMenu = await _menuManager.GetAsync(SideNavBarMenus.LeftSideMenu);
            return View("~/Themes/Layui/Components/SideNavBar/Default.cshtml", sideMenu);
        }
    }
}
