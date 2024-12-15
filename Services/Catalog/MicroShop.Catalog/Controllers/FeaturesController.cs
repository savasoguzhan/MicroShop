using Amazon.Util;
using MicroShop.Catalog.Dtos.FeatureDtos;
using MicroShop.Catalog.Services.FeatureServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureServices _featureServices;

        public FeaturesController(IFeatureServices featureServices)
        {
            _featureServices = featureServices;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _featureServices.GetAllFeatureAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(string id)
        {
            var value = await _featureServices.GetByIdFeatureAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureServices.CreateFeatureAsync(createFeatureDto);
            return Ok("Feature Added");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureServices.DeleteFeatureAsync(id);
            return Ok("FeatureDeleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureServices.UpdateFeatureAsync(updateFeatureDto);
            return Ok("Feature Updated");
        }

    }
}
