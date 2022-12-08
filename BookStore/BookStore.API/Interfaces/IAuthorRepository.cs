using BookStore.API.DTOs;
using BookStore.API.ViewModels;

namespace BookStore.API.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<AuthorViewModel>> GetAll(string? serachKey);
        Task<CreateAuthorDto> Create(CreateAuthorDto dto);
        Task<UpdateAuthorDto> Update(UpdateAuthorDto dto);
        Task<bool> Delete(int id);


    }
}
