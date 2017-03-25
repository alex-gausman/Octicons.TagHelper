using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TagHelpers = Microsoft.AspNetCore.Razor.TagHelpers;

namespace Octicons.TagHelper
{
    public class OcticonSpritesheetTagHelper: TagHelpers.TagHelper
    {
        public override void Process(TagHelpers.TagHelperContext context, TagHelpers.TagHelperOutput output)
        {
            output.TagName = "";
            output.Content.SetHtmlContent(Octicons.Instance.SpriteSheet);
        }
    }
}
