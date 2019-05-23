using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui.TagHelpers
{
    [HtmlTargetElement("taginput", Attributes = "tag-items")]
    public class TagInputTagHelper : AbpTagHelper
    {
        [HtmlAttributeName("tag-id")]
        public string Id { get; set; } = "";

        [HtmlAttributeName("tag-class")]
        public string Class { get; set; } = "layui-input";

        [HtmlAttributeName("tag-name")]
        public string Name { get; set; } = "";

        [HtmlAttributeName("tag-placeholder")]
        public string Placeholder { get; set; } = "";

        [HtmlAttributeName("tag-items")]
        public List<string> SelectedItems { get; set; } = new List<string>();

        [HtmlAttributeName("tag-required")]
        public bool Required { get; set; } = false;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "div";
            output.Attributes.Add(new TagHelperAttribute("class", "tags"));
            output.Attributes.Add(new TagHelperAttribute("id", "tags"));

            var inputTagBuilder = new TagBuilder("input");
            inputTagBuilder.Attributes.Add("name", Name);
            inputTagBuilder.Attributes.Add("class", Class);
            inputTagBuilder.Attributes.Add("id", Id);
            inputTagBuilder.Attributes.Add("placeholder", Placeholder);
            if (Required)
            {
                inputTagBuilder.Attributes.Add("required", null);
            }
            inputTagBuilder.Attributes.Add("value", SelectedItems.JoinAsString(","));

            output.Content.AppendHtml(inputTagBuilder);
        }
    }
}
