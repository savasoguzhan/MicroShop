using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
