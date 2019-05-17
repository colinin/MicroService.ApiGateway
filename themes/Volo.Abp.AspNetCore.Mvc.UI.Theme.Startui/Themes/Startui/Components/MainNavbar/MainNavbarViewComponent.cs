using Microsoft.AspNetCore.Mvc;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Startui.Themes.Startui.Components.MainNavbar
{
    public class MainNavbarViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/Startui/Components/MainNavbar/Default.cshtml");
        }
    }
}
