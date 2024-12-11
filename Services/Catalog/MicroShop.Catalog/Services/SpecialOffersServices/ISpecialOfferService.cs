using MicroShop.Catalog.Dtos.SpecialOfferDtos;

namespace MicroShop.Catalog.Services.SpecialOffersServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();

        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);

        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);

        Task DeleteSpecialOfferAsync(string id);

        Task<ResultSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
    }
}
