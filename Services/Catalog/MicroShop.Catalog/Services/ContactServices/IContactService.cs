using MicroShop.Catalog.Dtos.ContactDtos;

namespace MicroShop.Catalog.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();

        Task CreateContactAsync(CreateContactDto createContactDto);

        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);

        Task<ResultContactDto> GetByIdContactAsync(string id);
    }
}
