﻿using Microsoft.AspNetCore.Mvc;

namespace MicroShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
