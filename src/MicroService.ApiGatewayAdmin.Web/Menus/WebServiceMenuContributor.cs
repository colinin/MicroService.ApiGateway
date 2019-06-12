using MicroService.ApiGatewayAdmin.Domain.Localization.ApiGateway;
using MicroService.ApiGatewayAdmin;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace MicroService.ApiGateway.Menus
{
    public class WebServiceMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
            if (context.Menu.Name == SideNavBarMenus.LeftSideMenu)
            {
                await ConfigureSideMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<ApiGatewayResource>>();
            await Task.CompletedTask;
        }

        private async Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<ApiGatewayResource>>();
            context.Menu.Items.Insert(0, new ApplicationMenuItem("WebService.Logout", l["Menu:Logout"], "/Account/Logout"));
            await Task.CompletedTask;
        }

        private async Task ConfigureSideMenuAsync(MenuConfigurationContext context)
        {
            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<ApiGatewayResource>>();
            var oceloteMenu = new ApplicationMenuItem("WebService.Menu.Ocelot", l["Side:Ocelot"], "#");
            oceloteMenu.AddItem(new ApplicationMenuItem("WebService.Menu.Ocelot.Global", l["Side:Ocelot:Global"], "/OcelotConfiguration/Global"));
            oceloteMenu.AddItem(new ApplicationMenuItem("WebService.Menu.Ocelot.ReRoutes", l["Side:Ocelot:ReRoutes"], "/OcelotConfiguration/ReRoutes"));
            oceloteMenu.AddItem(new ApplicationMenuItem("WebService.Menu.Ocelot.Source", l["Side:Ocelot:Source"], "/OcelotConfiguration/Source"));

            var clusterOcelotMenu = new ApplicationMenuItem("WebService.Menu.ClusterOcelot", l["Side:ClusterOcelot"], "#");
            clusterOcelotMenu.AddItem(new ApplicationMenuItem("WebService.Menu.ClusterOcelot.ServerList", l["Side:ClusterOcelot:ServerList"], "/ClusterOcelot/ServerList"));

            context.Menu.Items.AddRange(new List<ApplicationMenuItem> { clusterOcelotMenu, oceloteMenu });

            await Task.CompletedTask;
        }
    }
}
