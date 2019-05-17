using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui.Localization.Layui;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Localization;
using Volo.Abp.Localization.Resources.AbpValidation;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule)
        )]
    public class AbpAspNetCoreMvcUiLayuiThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<ThemingOptions>(options =>
            {
                options.Themes.Add<LayuiTheme>();

                if (options.DefaultThemeName == null)
                {
                    options.DefaultThemeName = LayuiTheme.Name;
                }
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<LayuiResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Layui");
            });

            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAspNetCoreMvcUiLayuiThemeModule>("Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui");
            });

            Configure<ToolbarOptions>(options =>
            {
                options.Contributors.Add(new LayuiThemeMainTopToolbarContributor());
            });

            Configure<BundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(LayuiThemeBundles.Styles.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(StandardBundles.Styles.Global)
                            .AddContributors(typeof(LayuiThemeGlobalStyleContributor));
                    })
                    .Add(LayuiThemeBundles.Styles.TableFilter, bundle => bundle.AddFiles("/lib/layui/css/modules/tableFilter/tableFilter.css"));

                options
                    .ScriptBundles
                    .Add(LayuiThemeBundles.Scripts.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(StandardBundles.Scripts.Global)
                            .AddContributors(typeof(LayuiThemeGlobalScriptContributor));
                    })
                    .Add(LayuiThemeBundles.Scripts.TableFilter, bundle => bundle.AddFiles("/lib/layui/lay/modules/tableFilter.js"));
            });
        }
    }
}
