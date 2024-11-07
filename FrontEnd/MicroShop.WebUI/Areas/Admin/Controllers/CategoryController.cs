using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Home PAge";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Category List";
            ViewBag.title = "Category Operation";
            return View();
        }
    }
}
