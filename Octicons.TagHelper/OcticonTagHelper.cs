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
        /// For use with <see cref="OcticonSpriteSheetTagHelper"/>.
        /// </summary>
        private const string UseSpriteAttributeName = "use-sprite";

        /// <summary>
        /// Optional height. If not set will use Octicon default.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Optional width. If not set will use Octicon default.
        /// </summary>
        public int? Width { get; set; }
        
        private const string Version = "1.1";
        private Octicons _octicons = Octicons.Instance;
        private string ViewBox() => $"0 0 {Width} {Height}";
        private string Svg(bool useSprite) =>
            useSprite ? $"<use xlink:href=\"#{Octicons.SymbolName(Symbol)}\" />" : _octicons.Symbol(Symbol).Path;

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
            var useSpriteAttribute = new TagHelpers.TagHelperAttribute(UseSpriteAttributeName);
            bool useSprite = context.AllAttributes.Contains(useSpriteAttribute);
            var octicon = _octicons.Symbol(Symbol);
            CalculateSize(octicon);
            output.TagName = "svg";
            output.Content.SetHtmlContent(Svg(useSprite));
            output.Attributes.Add("viewBox", ViewBox());
            output.Attributes.Add("width", Width.ToString());
            output.Attributes.Add("height", Height.ToString());
            output.Attributes.Add("version", Version);
        }
    }
}
