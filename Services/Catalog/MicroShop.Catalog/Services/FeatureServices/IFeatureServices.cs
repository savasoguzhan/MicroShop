using MicroShop.Catalog.Dtos.FeatureDtos;

namespace MicroShop.Catalog.Services.FeatureServices
{
    public interface IFeatureServices
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();

        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);

        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);

        Task DeleteFeatureAsync(string id);

        Task<ResultFeatureDto> GetByIdFeatureAsync(string id);
    }
}
