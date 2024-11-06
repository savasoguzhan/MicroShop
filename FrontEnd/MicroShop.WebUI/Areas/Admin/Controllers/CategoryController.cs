using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
