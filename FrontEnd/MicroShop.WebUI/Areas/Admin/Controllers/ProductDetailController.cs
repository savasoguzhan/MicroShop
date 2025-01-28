using MicroShop.Dto.CatologDtos.ProductDetailDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MicroShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessge = await client.GetAsync("https://localhost:7200/api/ProductDetails/" + id);
            if(responseMessge.IsSuccessStatusCode)
            {
                var jsonData = await responseMessge.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetalDto>(jsonData);
                return Ok(values);

            }
            return View();

        }


        [HttpPost]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetalDto updateProductDetalDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDetalDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7200/api/ProductDetails/", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Category",new {area ="Admin"});
            }
            return View();
        }
    }
}
