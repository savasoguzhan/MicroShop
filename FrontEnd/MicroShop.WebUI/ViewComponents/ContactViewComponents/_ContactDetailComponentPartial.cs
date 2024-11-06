using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebUI.ViewComponents.ContactViewComponents
{
    public class _ContactDetailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
