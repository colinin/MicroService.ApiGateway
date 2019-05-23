using Microsoft.AspNetCore.Mvc.Razor.Extensions;
using Microsoft.AspNetCore.Razor.Language;
using System.Collections.Generic;
using System.Linq;

namespace MicroService.ApiGateway.Web.Razor
{
    public class ApiGatewayRazorTemplateEngine : MvcRazorTemplateEngine
    {
        public ApiGatewayRazorTemplateEngine(RazorEngine engine, RazorProject project) 
            : base(engine, project)
        {

        }

        public override IEnumerable<RazorProjectItem> GetImportItems(RazorProjectItem projectItem)
        {
            var importsItems = base.GetImportItems(projectItem);
            importsItems.Append(Project.GetItem($"/Views/{ Options.ImportsFileName }"));
            return importsItems;
        }
    }
}
