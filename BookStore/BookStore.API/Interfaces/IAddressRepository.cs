using BookStore.API.DTOs;
using BookStore.API.Models;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<AddressViewModel>> GetAll();


        Task<CreateAddressDto> Create(CreateAddressDto dto);


        Task<UpdateAddressDto> Update(UpdateAddressDto dto);


        Task<bool> Delete(int id);
      
    }
}
