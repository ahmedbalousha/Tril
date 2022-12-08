using AutoMapper;
using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public ZoneRepository(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<ZoneViewModel>> GetAll(string? serachKey)
        {
            var zones = await _context.Zones.Where(x => x.Name.Contains(serachKey)
            || string.IsNullOrEmpty(serachKey)).Select(x => new ZoneViewModel()
            {   Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
            return zones;
        }

        public async Task<CreateZoneDto> Create(CreateZoneDto dto)
        {
            var zone = _mapper.Map<Zone>(dto);
            await _context.Zones.AddAsync(zone);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<UpdateZoneDto> Update(UpdateZoneDto dto)
        {
            var zone = await _context.Zones.SingleOrDefaultAsync(x => x.Id == dto.Id);

            if (zone == null)
                throw new ArgumentException("Item Not Found");
            else
            {

                var updatedZones = _mapper.Map(dto, zone);
                var updatedZonesVM = _mapper.Map<Zone, UpdateZoneDto>(zone, dto);
                _context.Zones.Update(updatedZones);
                await _context.SaveChangesAsync();
                return updatedZonesVM;

            }
           
        }

        public async Task<bool> Delete(int id)
        {
            var zone = await _context.Zones.FindAsync(id);
            if (zone == null)
                return false;
            else
            {
                _context.Zones.Remove(zone);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

    }
}
