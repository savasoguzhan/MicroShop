using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
