﻿using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial : ViewComponent    
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
