using MicroShop.Discount.Dtos;

namespace MicroShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponsAsync();

        Task CreateCouponAsync(CreateCouponDto createCouponDto);

        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);

        Task<ResultCouponDto> GetByIdCouponAsync(int id);
    }
}
