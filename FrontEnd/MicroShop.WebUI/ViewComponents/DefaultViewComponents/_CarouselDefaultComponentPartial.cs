using MicroShop.Dto.CatologDtos.FeatureSliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarouselDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessge = await client.GetAsync("https://localhost:7200/api/FeatureSliders");
            if(responseMessge.IsSuccessStatusCode)
            {
                var jsonData = await responseMessge
                    .Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
