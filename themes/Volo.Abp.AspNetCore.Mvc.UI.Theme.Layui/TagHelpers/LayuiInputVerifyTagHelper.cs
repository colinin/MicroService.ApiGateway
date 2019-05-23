using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui.TagHelpers
{
    [HtmlTargetElement("input", Attributes = "l-verfy")]
    public class LayuiInputVerifyTagHelper : InputTagHelper
    {
        [HtmlAttributeName("l-verfy")]
        public string Verify { get; set; }
        public LayuiInputVerifyTagHelper(IHtmlGenerator generator) 
            : base(generator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrWhiteSpace(Verify))
            {
                output.Attributes.Add("lay-verify", Verify);
            }

            base.Process(context, output);
        }
    }
}
