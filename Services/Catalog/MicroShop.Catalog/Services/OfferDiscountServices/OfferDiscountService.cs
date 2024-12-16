﻿using AutoMapper;
using MicroShop.Catalog.Dtos.OfferDiscountDtos;
using MicroShop.Catalog.Entities;
using MicroShop.Catalog.Settings;
using MongoDB.Driver;

namespace MicroShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;

        public OfferDiscountService(IMapper mapper, IDataBaseSettings _dataBaseSettings)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);

            _offerDiscountCollection = database.GetCollection<OfferDiscount>(_dataBaseSettings.OfferDiscountCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var value = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
            await _offerDiscountCollection.InsertOneAsync(value);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _offerDiscountCollection.DeleteOneAsync(x =>x.OfferDiscountId==id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var values = await _offerDiscountCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultOfferDiscountDto>>(values);
        }

        public async Task<ResultOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var values = await _offerDiscountCollection.Find<OfferDiscount>(x=>x.OfferDiscountId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultOfferDiscountDto>(values);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var values =  _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
            await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.OfferDiscountId == updateOfferDiscountDto.OfferDiscountId, values);
        }
    }
}
