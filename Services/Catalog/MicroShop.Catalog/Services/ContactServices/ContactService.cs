using AutoMapper;
using MicroShop.Catalog.Dtos.ContactDtos;
using MicroShop.Catalog.Entities;
using MicroShop.Catalog.Settings;
using MongoDB.Driver;

namespace MicroShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Contact> _contactCollection;

        public ContactService(IMapper mapper, IDataBaseSettings _dataBaseSettings)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_dataBaseSettings.ContactCollectionName);
            _mapper = mapper;
        }
        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
           var value = _mapper.Map<Contact>(createContactDto);
            await _contactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
           await _contactCollection.DeleteOneAsync(x =>x.ContactID==id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task<ResultContactDto> GetByIdContactAsync(string id)
        {
            var values = await _contactCollection.Find<Contact>(x =>x.ContactID==id).FirstOrDefaultAsync();
            return _mapper.Map<ResultContactDto>(values);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
           var values = _mapper.Map<Contact>(updateContactDto);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactID == updateContactDto.ContactID, values);
        }
    }
}
