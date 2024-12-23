using MicroShop.Catalog.Dtos.AboutDtos;
using MicroShop.Catalog.Dtos.BrandDtos;

namespace MicroShop.Catalog.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutsAsync();

        Task CreateAboutAsync(CreateAboutDto createAboutDto);

        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(string id);

        Task<ResultAboutDto> GetByIdAboutAsync(string id);
    }
}
