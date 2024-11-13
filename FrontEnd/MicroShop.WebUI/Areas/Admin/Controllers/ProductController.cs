using MicroShop.Dto.CatologDtos.CategoryDtos;
using MicroShop.Dto.CatologDtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace MicroShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home PAge";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "Product Operation";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7200/api/Products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Home PAge";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "Product Operation";
            var client = _httpClientFactory.CreateClient();
            var responseMessge = await client.GetAsync("https://localhost:7200/api/Categories");
            var jsonData = await responseMessge.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryValue = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName,
                                                      Value=x.CategoryID
                                                  }).ToList();

            ViewBag.CategoryValue = categoryValue;

            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7200/api/Products", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Product", new {area="Admin"});
            }
            return View();
        }


        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage =await client.DeleteAsync("https://localhost:7200/api/Products?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();  
        }

        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {


            var client1 = _httpClientFactory.CreateClient();
            var responseMessge1 = await client1.GetAsync("https://localhost:7200/api/Categories");
            var jsonData1 = await responseMessge1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
            List<SelectListItem> categoryValue1 = (from x in values1
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID
                                                  }).ToList();

            ViewBag.CategoryValue = categoryValue1;






            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7200/api/Products/" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);    
            }
            return View();
        }


        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMessage = await client.PutAsync("https://localhost:7200/api/Products/", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
