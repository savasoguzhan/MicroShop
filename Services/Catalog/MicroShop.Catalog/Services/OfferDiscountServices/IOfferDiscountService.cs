using MicroShop.Catalog.Dtos.OfferDiscountDtos;

namespace MicroShop.Catalog.Services.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();

        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
        Task DeleteOfferDiscountAsync(string id);

        Task<ResultOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
    }
}
