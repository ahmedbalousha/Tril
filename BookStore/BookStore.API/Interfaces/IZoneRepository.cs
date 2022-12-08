using BookStore.API.DTOs;
using BookStore.API.ViewModels;

namespace BookStore.API.Interfaces
{
    public interface IZoneRepository
    {
        Task<List<ZoneViewModel>> GetAll(string serachKey);
        Task<CreateZoneDto> Create(CreateZoneDto dto);
        Task<UpdateZoneDto> Update(UpdateZoneDto dto);
        Task<bool> Delete(int id);
    }
}
