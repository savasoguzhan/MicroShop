using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInfoComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
