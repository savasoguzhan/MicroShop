using AutoMapper;
using MicroShop.Catalog.Dtos.ProductDtos;
using MicroShop.Catalog.Entities;
using MicroShop.Catalog.Settings;
using MongoDB.Driver;

namespace MicroShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductService(IMapper mapper, IDataBaseSettings _dataBaseSettings)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_dataBaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_dataBaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductID == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
          var values = await _productCollection.Find(x => true).ToListAsync();
           return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<ResultProductDto> GetByIdProductAsync(string id)
        {
            var values = await  _productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
           return _mapper.Map<ResultProductDto>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category= await _categoryCollection.Find<Category>(x=>x.CategoryID==item.CategoryID).FirstAsync();
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
        {
            var values = await _productCollection.Find(x =>x.CategoryID==categoryId).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryID == item.CategoryID).FirstAsync();
            }

            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
           var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductID ==updateProductDto.ProductID, values);
        }
    }
}
