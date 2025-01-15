using AutoMapper;
using MicroShop.Catalog.Dtos.ProductImagesDtos;
using MicroShop.Catalog.Entities;
using MicroShop.Catalog.Settings;
using MongoDB.Driver;

namespace MicroShop.Catalog.Services.ProductImagesServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImages> _productImageCollection;

        public ProductImageService(IMapper mapper, IDataBaseSettings _dataBaseSettings)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImages>(_dataBaseSettings.ProductImagesCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImages>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(value);
            
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImagesID == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<ResultProductImageDto> GetByIdProductImageAsync(string id)
        {
            var value = await _productImageCollection.Find<ProductImages>(x=>x.ProductImagesID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductImageDto>(value);
        }

        public async Task<ResultProductImageDto> GetByProductIdProductImageAsync(string id)
        {
            var values = await _productImageCollection.Find(x => x.ProductID==id).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductImageDto>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProducyImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImages>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImagesID == updateProductImageDto.ProductImagesID, values);
        }
    }
}
