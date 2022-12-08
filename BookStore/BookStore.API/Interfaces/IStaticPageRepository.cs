using BookStore.API.DTOs;
using BookStore.API.Models;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Interfaces
{
    public interface IStaticPageRepository
    {
        Task<List<StaticPageViewModel>> GetAll();


        Task<CreateStaticPageDto> Create(CreateStaticPageDto dto);


        Task<UpdateStaticPageDto> Update(UpdateStaticPageDto dto);


        Task<bool> Delete(int id);
       

    }
}
