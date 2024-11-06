using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
