using AutoMapper;
using MicroShop.Catalog.Dtos.BrandDtos;
using MicroShop.Catalog.Entities;
using MicroShop.Catalog.Settings;
using MongoDB.Driver;
using System.Net.WebSockets;

namespace MicroShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Brand> _brandCollection;

        public BrandService(IMapper mapper, IDataBaseSettings _dataBaseSettings)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _brandCollection = database.GetCollection<Brand>(_dataBaseSettings.BrandCollectionName);
            _mapper = mapper;
        }
        public async  Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var value = _mapper.Map<Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(value);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(x =>x.BrandID==id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
        {
           var values = await _brandCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(values);
        }

        public async Task<ResultBrandDto> GetByIdBrandAsync(string id)
        {
            var value = await _brandCollection.Find<Brand>(x => x.BrandID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultBrandDto>(value);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var values = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.BrandID == updateBrandDto.BrandID, values);
        }
    }
}
