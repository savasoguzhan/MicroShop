using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebUI.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
