using BookStore.API.DTOs;
using BookStore.API.Models;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Interfaces
{
    public interface ITranslatorRepository
    {
        Task<List<TranslatorViewModel>> GetAll(string? serachKey);


        Task<CreateTranslatorDto> Create(CreateTranslatorDto dto);


        Task<UpdateTranslatorDto> Update(UpdateTranslatorDto dto);


        Task<bool> Delete(int id);
        
    }
}
