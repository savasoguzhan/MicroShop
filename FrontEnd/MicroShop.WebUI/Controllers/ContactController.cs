using MicroShop.Dto.CatologDtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MicroShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.IsRead = false;
            createContactDto.SendDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(JsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7200/api/Contacts", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View();
        }
    }
}
