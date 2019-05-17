using Volo.Abp.AspNetCore.Mvc.UI.Theme.Startui.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Startui.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Microsoft.Extensions.DependencyInjection;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Startui
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule)
        )]
    public class AbpAspNetCoreMvcUiStartUiThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<ThemingOptions>(options =>
            {
                options.Themes.Add<StartuiTheme>();

                if (options.DefaultThemeName == null)
                {
                    options.DefaultThemeName = StartuiTheme.Name;
                }
            });

            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAspNetCoreMvcUiStartUiThemeModule>("Volo.Abp.AspNetCore.Mvc.UI.Theme.Startui");
            });

            Configure<ToolbarOptions>(options =>
            {
                options.Contributors.Add(new StartuiThemeMainTopToolbarContributor());
            });

            Configure<BundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(StartuiThemeBundles.Styles.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(StandardBundles.Styles.Global)
                            .AddContributors(typeof(StartuiThemeGlobalStyleContributor));
                    });

                options
                    .ScriptBundles
                    .Add(StartuiThemeBundles.Scripts.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(StandardBundles.Scripts.Global)
                            .AddContributors(typeof(StartuiThemeGlobalScriptContributor));
                    });
            });
        }
    }
}
