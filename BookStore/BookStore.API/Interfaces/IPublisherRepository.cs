using BookStore.API.DTOs;
using BookStore.API.ViewModels;

namespace BookStore.API.Interfaces
{
    public interface IPublisherRepository
    {
        Task<List<PublisherViewModel>> GetAll(string? serachKey);
        Task<CreatePublisherDto> Create(CreatePublisherDto dto);
        Task<UpdatePublisherDto> Update(UpdatePublisherDto dto);
        Task<bool> Delete(int id);

    }
}
