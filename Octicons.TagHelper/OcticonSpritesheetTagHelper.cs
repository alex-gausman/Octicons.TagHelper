using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TagHelpers = Microsoft.AspNetCore.Razor.TagHelpers;

namespace Octicons.TagHelper
{
    [TagHelpers.HtmlTargetElement("svg", Attributes = "octicon-sprites")]
    public class OcticonSpritesheetTagHelper: TagHelpers.TagHelper
    {
        private const string OcticonSpritesAttributeName = "octicon-sprites";

        public override void Process(TagHelpers.TagHelperContext context, TagHelpers.TagHelperOutput output)
        {
            var octiconSpritesAttribute = new TagHelpers.TagHelperAttribute(OcticonSpritesAttributeName);
            if (context.AllAttributes.Contains(octiconSpritesAttribute))
            {
                output.Attributes.Remove(octiconSpritesAttribute);
                output.Content.SetHtmlContent(Octicons.Instance.SpriteSheet);
            }
        }
    }
}
