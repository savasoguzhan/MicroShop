using MicroShop.Basket.Dtos;
using MicroShop.Basket.Settings;
using System.Text.Json;

namespace MicroShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }
        public async Task DeleteBasket(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
           var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
            
        }

        public async Task SaveBasket(BasketTotalDto basket)
        {
            await _redisService.GetDb().StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));
        }
    }
}
