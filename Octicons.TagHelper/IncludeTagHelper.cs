using System;
using System.Collections.Generic;
using System.Text;
using TagHelpers = Microsoft.AspNetCore.Razor.TagHelpers;

namespace Octicons.TagHelper
{
    [TagHelpers.HtmlTargetElement(ParentTag = "octicon-sprite-sheet")]
    public class IncludeTagHelper : TagHelpers.TagHelper
    {
        public OcticonSymbol Symbol { get; set; }

        private Octicons _octicons = Octicons.Instance;

        public override void Process(TagHelpers.TagHelperContext context, TagHelpers.TagHelperOutput output)
        {
            var name = Octicons.SymbolName(Symbol);
            var octicon = _octicons.Symbol(Symbol);
            //var symbolStartTag = $"<symbol viewBox=\"0 0 {octicon.Width} {octicon.Height}\" id=\"{name}\">";
            //var symbolEndTag = "</symbol>";

            output.TagName = "symbol";
            output.Attributes.Add("id", name);
            output.Attributes.Add("viewBox", $"0 0 {octicon.Width} {octicon.Height}");
            output.Content.SetHtmlContent(octicon.Path);
        }
    }
}
