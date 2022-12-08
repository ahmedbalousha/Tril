using BookStore.API.DTOs;
using BookStore.API.ViewModels;

namespace BookStore.API.Interfaces
{
    public interface IBookSuggestionRepository
    {
         Task<List<BookSuggestionViewModel>> GetAll();


         Task<CreateBookSuggestionDto> Create(CreateBookSuggestionDto dto);

        Task<UpdateBookSuggestionDto> Update(UpdateBookSuggestionDto dto);


        Task<bool> Delete(int id);
        
    }
}
