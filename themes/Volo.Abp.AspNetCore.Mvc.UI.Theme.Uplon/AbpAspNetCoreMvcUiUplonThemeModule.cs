using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Uplon.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Uplon.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Uplon
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule)
        )]
    public class AbpAspNetCoreMvcUiUplonThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<ThemingOptions>(options =>
            {
                options.Themes.Add<UplonTheme>();

                if (options.DefaultThemeName == null)
                {
                    options.DefaultThemeName = UplonTheme.Name;
                }
            });

            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAspNetCoreMvcUiUplonThemeModule>("Volo.Abp.AspNetCore.Mvc.UI.Theme.Uplon");
            });

            Configure<ToolbarOptions>(options =>
            {
                options.Contributors.Add(new UplonThemeMainTopToolbarContributor());
            });

            Configure<BundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(UplonThemeBundles.Styles.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(StandardBundles.Styles.Global)
                            .AddContributors(typeof(UplonThemeGlobalStyleContributor));
                    })
                    .Add(UplonThemeBundles.Styles.JsTree, bundle => bundle.AddFiles("/plugins/jstree/style.css"))
                    .Add(UplonThemeBundles.Styles.C3Chart, bundle => bundle.AddFiles("/plugins/charts/c3/c3.css"))
                    .Add(UplonThemeBundles.Styles.MinC3Chart, bundle => bundle.AddFiles("/plugins/charts/c3/c3.min.css"))
                    .Add(UplonThemeBundles.Styles.MultiDataTable, bundle => bundle.AddFiles("/plugins/datatables/css/select.bootstrap4.min.css"));

                options
                    .ScriptBundles
                    .Add(UplonThemeBundles.Scripts.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(StandardBundles.Scripts.Global)
                            .AddContributors(typeof(UplonThemeGlobalScriptContributor));
                    })
                    .Add(UplonThemeBundles.Scripts.MinJsTree, bundle => bundle.AddFiles("/plugins/jstree/jstree.min.js", "/plugins/jstree/jquery.tree.js"))
                    .Add(UplonThemeBundles.Scripts.JsTree, bundle => bundle.AddFiles("/plugins/jstree/jstree.js", "/plugins/jstree/jquery.tree.js"))
                    .Add(UplonThemeBundles.Scripts.MinC3Chart, bundle => bundle.AddFiles("/plugins/charts/d3/d3.min.js", "/plugins/charts/c3/c3.min.js"))
                    .Add(UplonThemeBundles.Scripts.C3Chart, bundle => bundle.AddFiles("/plugins/charts/d3/d3.js", "/plugins/charts/c3/c3.js"))
                    .Add(UplonThemeBundles.Scripts.MultiDataTable, bundle => bundle.AddFiles("/plugins/datatables/js/dataTables.select.min.js", "/plugins/datatables/js/multitables.js"));
            });
        }
    }
}
