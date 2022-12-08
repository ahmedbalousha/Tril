using BookStore.API.DTOs;
using BookStore.API.ViewModels;

namespace BookStore.API.Interfaces
{
    public interface ISaleRepository
    {
        Task<List<SaleViewModel>> GetAll();
        Task<CreateSaleDto> Create(CreateSaleDto dto);
        Task<bool> Delete(int id);
    }
}
