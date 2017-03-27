using System.Threading.Tasks;
using TagHelpers = Microsoft.AspNetCore.Razor.TagHelpers;

namespace Octicons.TagHelper
{
    [TagHelpers.RestrictChildren("include")]
    public class OcticonSpriteSheetTagHelper : TagHelpers.TagHelper
    {
        private const string svgNamespace = "http://www.w3.org/2000/svg";

        public override async Task ProcessAsync(TagHelpers.TagHelperContext context, TagHelpers.TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            
            output.TagName = "svg";
            output.Attributes.Add("xmlns", svgNamespace);

            if (content.IsEmptyOrWhiteSpace)
                output.Content.SetHtmlContent(Octicons.Instance.SpriteSheet);
        }
    }
}
