using MicroShop.Catalog.Dtos.ProductImagesDtos;

namespace MicroShop.Catalog.Services.ProductImagesServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();

        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);

        Task UpdateProductImageAsync(UpdateProducyImageDto updateProductImageDto);

        Task DeleteProductImageAsync(string id);

        Task<ResultProductImageDto> GetByIdProductImageAsync(string id);
    }
}
