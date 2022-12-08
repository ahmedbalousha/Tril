using AutoMapper;
using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class ContantUsRepository : IContantUsRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public ContantUsRepository(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<ContantUsViewModel>> GetAll()
        {
            var contantUss = await _context.ContantUss.ToListAsync();
            var contantUssVM = _mapper.Map<List<ContantUsViewModel>>(contantUss);
            return contantUssVM;
        }

        public async Task<CreateContantUsDto> Create(CreateContantUsDto dto)
        {
            var contantUs = _mapper.Map<ContantUs>(dto);
            await _context.ContantUss.AddAsync(contantUs);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<UpdateContantUsDto> Update(UpdateContantUsDto dto)
        {
            var contantUs = await _context.ContantUss.SingleOrDefaultAsync(x => x.Id == dto.Id);

            if (contantUs == null)
                throw new ArgumentException("Item Not Found");
            else
            {

                var updatedContantUs = _mapper.Map(dto, contantUs);
                var updatedContantUsVM = _mapper.Map<ContantUs, UpdateContantUsDto>(contantUs, dto);
                _context.ContantUss.Update(updatedContantUs);
                await _context.SaveChangesAsync();
                return updatedContantUsVM;

            }
           
        }

        public async Task<bool> Delete(int id)
        {
            var contantUs = await _context.ContantUss.FindAsync(id);
            if (contantUs == null)
                return false;
            else
            {
                _context.ContantUss.Remove(contantUs);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

    }
}
