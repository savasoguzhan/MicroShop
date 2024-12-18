using MicroShop.Catalog.Dtos.BrandDtos;

namespace MicroShop.Catalog.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandsAsync();

        Task CreateBrandAsync(CreateBrandDto createBrandDto);

        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
            
        Task DeleteBrandAsync(string id);

        Task<ResultBrandDto> GetByIdBrandAsync(string id);
    }
}
