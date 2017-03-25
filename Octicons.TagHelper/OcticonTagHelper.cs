using System;
using TagHelpers = Microsoft.AspNetCore.Razor.TagHelpers;

namespace Octicons.TagHelper
{
    /// <summary>
    /// A tag helper for GitHub's Octicon icons.
    /// </summary>
    public class OcticonTagHelper : TagHelpers.TagHelper
    {
        /// <summary>
        /// The Octicon symbol to display
        /// </summary>
        public OcticonSymbol Symbol { get; set; }

        /// <summary>
        /// Use this option to reference the Octicon from the external spritesheet.
        /// For use with <see cref="OcticonSpritesheetTagHelper"/>.
        /// </summary>
        public bool SvgUse { get; set; }

        /// <summary>
        /// Optional height. If not set will use Octicon default.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Optional width. If not set will use Octicon default.
        /// </summary>
        public int? Width { get; set; }

        private string Version { get; set; } = "1.1";
        private Octicons _octicons = Octicons.Instance;
        private string ViewBox() => $"0 0 {Width} {Height}";
        private string SymbolName() => Enum.GetName(Symbol.GetType(), Symbol).ToLower();
        private string Svg() =>
            SvgUse ? $"<use xlink:href=\"#{SymbolName()}\" />" : _octicons.Symbol(SymbolName()).Path;

        private int CalculateWidth(int height, Octicon octicon) => (height * octicon.Width) / octicon.Height;

        private int CalculateHeight(int width, Octicon octicon) => (width * octicon.Height) / octicon.Width;

        private void CalculateSize(Octicon octicon)
        {
            if (Width.HasValue || Height.HasValue)
            {
                Width = Width ?? CalculateWidth(Height.Value, octicon); 
                Height = Height ?? CalculateHeight(Width.Value, octicon);
            }
            else
            {
                Width = octicon.Width;
                Height = octicon.Height;
            }
        }

        public override void Process(TagHelpers.TagHelperContext context, TagHelpers.TagHelperOutput output)
        {
            var octicon = _octicons.Symbol(SymbolName());
            CalculateSize(octicon);
            output.TagName = "svg";
            output.Content.SetHtmlContent(Svg());
            output.Attributes.Add("viewBox", ViewBox());
            output.Attributes.Add("width", Width.ToString());
            output.Attributes.Add("height", Height.ToString());
            output.Attributes.Add("version", Version);
        }
    }
}
