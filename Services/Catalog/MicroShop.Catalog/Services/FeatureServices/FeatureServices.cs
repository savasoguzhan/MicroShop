using AutoMapper;
using MicroShop.Catalog.Dtos.FeatureDtos;
using MicroShop.Catalog.Entities;
using MicroShop.Catalog.Settings;
using MongoDB.Driver;

namespace MicroShop.Catalog.Services.FeatureServices
{
    public class FeatureServices : IFeatureServices
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Feature> _featureCollection;

        public FeatureServices(IMapper mapper,IDataBaseSettings _dataBaseSettings )
        {
            var client = new MongoClient( _dataBaseSettings.ConnectionString );
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName );
            _featureCollection = database.GetCollection<Feature>(_dataBaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }
        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
           var value = _mapper.Map<Feature>(createFeatureDto);
            await _featureCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x =>x.FeatureID==id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var values = await _featureCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<ResultFeatureDto> GetByIdFeatureAsync(string id)
        {
            var value = await _featureCollection.Find<Feature>(x => x.FeatureID==id).FirstOrDefaultAsync();
            return _mapper.Map<ResultFeatureDto>(value);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
           var values = _mapper.Map<Feature>(updateFeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureID == updateFeatureDto.FeatureID, values);
        }
    }
}
