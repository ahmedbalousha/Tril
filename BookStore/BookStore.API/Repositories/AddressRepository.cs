using AutoMapper;
using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AddressRepository(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<AddressViewModel>> GetAll()
        {
            var address = await _context.Addresses.Include(x => x.Zone).ToListAsync();
            var addressVM = _mapper.Map<List<AddressViewModel>>(address);
            return addressVM;
        }

        public async Task<CreateAddressDto> Create(CreateAddressDto dto)
        {
            var address = _mapper.Map<Address>(dto);
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<UpdateAddressDto> Update(UpdateAddressDto dto)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(x => x.Id == dto.Id);

            if (address == null)
                throw new ArgumentException("Item Not Found");
            else
            {

                var updatedAddress = _mapper.Map(dto, address);
                var updatedAddressVM = _mapper.Map<Address, UpdateAddressDto>(address, dto);
                _context.Addresses.Update(updatedAddress);
                await _context.SaveChangesAsync();
                return updatedAddressVM;

            }
           
        }

        public async Task<bool> Delete(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
                return false;
            else
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

    }
}
