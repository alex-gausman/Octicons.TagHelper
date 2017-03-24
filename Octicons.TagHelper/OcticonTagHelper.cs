using System;
using System.Collections.Generic;
using System.IO;
using TagHelpers = Microsoft.AspNetCore.Razor.TagHelpers;

namespace Octicons.TagHelper
{
    public class OcticonTagHelper : TagHelpers.TagHelper
    {
        private string _spriteSheet;
        private List<OcticonSymbol> _octiconSymbols;

        public OcticonTagHelper()
        {
            //File.ReadAllText(Directory.GetCurrentDirectory())
        }

        public override void Process(TagHelpers.TagHelperContext context, TagHelpers.TagHelperOutput output)
        {
            output.TagName = "a";
        }
    }
}
