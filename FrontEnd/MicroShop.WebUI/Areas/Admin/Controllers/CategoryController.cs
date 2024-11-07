using MicroShop.Dto.CatologDtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home PAge";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Category List";
            ViewBag.title = "Category Operation";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7200/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
