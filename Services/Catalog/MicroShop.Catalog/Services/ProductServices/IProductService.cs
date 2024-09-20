using MicroShop.Catalog.Dtos.CategoryDtos;
using MicroShop.Catalog.Dtos.ProductDtos;

namespace MicroShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();

        Task CreateProductAsync(CreateProductDto createProductDto);

        Task UpdateProductAsync(UpdateProductDto updateProductDto); 

        Task DeleteProductAsync(string id);

        Task<ResultProductDto> GetByIdProductAsync(string id);
    }
}
