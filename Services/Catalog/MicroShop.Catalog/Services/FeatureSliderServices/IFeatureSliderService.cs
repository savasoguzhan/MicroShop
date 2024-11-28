using MicroShop.Catalog.Dtos.FeatureSliderDtos;
using System.Globalization;

namespace MicroShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeaturesSliderAsync();

        Task CreateFeatureAsync(CreateFeatureSliderDto createFeatureSliderDto);

        Task UpdateFeatureAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureAsync(string id);

        Task<ResultFeatureSliderDto> GetByIdFeatureSliderAsync(string id);

        Task FeatureSliderChangeStatusToTrue(string id);
        Task FeatureSliderChangeStatusToFalse(string id);
    }
}
