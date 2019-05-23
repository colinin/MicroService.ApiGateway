using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers;

namespace MicroService.ApiGateway.Web.TagHelpers.Bootstrap
{
    [HtmlTargetElement("b-taginput", Attributes = "b-tag-items")]
    public class TagsInputTagHelper : AbpTagHelper
    {
        [HtmlAttributeName("b-tag-items")]
        public List<string> SelectedItems { get; set; } = new List<string>();

        [HtmlAttributeName("b-tag-required")]
        public bool Required { get; set; } = false;

        [HtmlAttributeName("b-tag-autocomplete")]
        public bool AutoComplete { get; set; } = false;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagOnly;
            output.TagName = "input";
            output.Attributes.Add("type", "text");
            if (Required)
            {
                output.Attributes.Add("required", null);
            }
            if (AutoComplete)
            {
                output.Attributes.Add("autocomplete", "on");
            }
            else
            {
                output.Attributes.Add("autocomplete", "off");
            }
            output.Attributes.Add("value", SelectedItems.JoinAsString(","));
        }
    }
}
