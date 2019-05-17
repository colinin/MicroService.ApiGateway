```C#
// the webmodule
[DependsOn(
        typeof(DemoApplicationModule),
        typeof(DemoEntityFrameworkCoreModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMvcUiUplonThemeModule)
        )]
 public class DemoWebWebModule : AbpModule
 {
     
 }
```

```C#
// the cshtml

@page
@using MicroService.ApiGateway.Pages
@using Volo.Abp.AspNetCore.Mvc.UI.Theming
@using Microsoft.Extensions.Options;
@using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
@inject IThemeManager ThemeManager
@inherits WebServicePageBase
@inject IOptions<BundlingOptions> Bundling
@model IndexModel
@section styles {
    @*add jstree
    <abp-style-bundle name="@UplonThemeBundles.Styles.JsTree" />*@
    @*add c3 chart
    <abp-style-bundle name="@UplonThemeBundles.Styles.MinC3Chart" />*@
}
@section scripts{
    @*add jstree
    <abp-script-bundle name="@UplonThemeBundles.Scripts.MinJsTree" />*@
    @*add c3 chart
    <abp-script-bundle name="@UplonThemeBundles.Scripts.MinC3Chart" />*@
}
@{
    ViewBag.FluidLayout = true;
}
```
