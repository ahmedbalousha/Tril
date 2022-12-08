using BookStore.API.DTOs;
using BookStore.API.Models;
using BookStore.API.ViewModels;

namespace BookStore.API.Interface
{
    public interface ICategoryRepository
    {
        Task<List<CategoryViewModel>> GetAll(string serachKey);
        Task<CreateCategoryDto> Create(CreateCategoryDto dto);
        Task<UpdateCategoryDto> Update( UpdateCategoryDto dto);
        Task<bool> Delete(int id);
    }
}
