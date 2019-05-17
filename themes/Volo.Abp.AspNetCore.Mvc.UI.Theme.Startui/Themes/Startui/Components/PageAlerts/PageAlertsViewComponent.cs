using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Alerts;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Startui.Themes.Startui.Components.PageAlerts
{
    public class PageAlertsViewComponent : AbpViewComponent
    {
        private readonly IAlertManager _alertManager;

        public PageAlertsViewComponent(IAlertManager alertManager)
        {
            _alertManager = alertManager;
        }

        public IViewComponentResult Invoke(string name)
        {
            return View("~/Themes/Startui/Components/PageAlerts/Default.cshtml", _alertManager.Alerts);
        }
    }
}
