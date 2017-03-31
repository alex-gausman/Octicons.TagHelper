using Microsoft.AspNetCore.Mvc;

namespace Octicons.TagHelper.Examples.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SpriteSheet()
        {
            return View();
        }

        public IActionResult SpriteSheetInclude()
        {
            return View();
        }
    }
}
