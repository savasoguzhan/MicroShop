using MicroShop.Catalog.Dtos.ProductDetailsDtos;

namespace MicroShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();

        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);

        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);

        Task DeleteProductDetailAsync(string id);

        Task<ResultProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
