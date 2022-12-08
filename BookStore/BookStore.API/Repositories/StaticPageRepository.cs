using AutoMapper;
using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class StaticPageRepository : IStaticPageRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public StaticPageRepository(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<StaticPageViewModel>> GetAll()
        {
            var staticPages = await _context.StaticPages.ToListAsync();
            var staticPagesVM = _mapper.Map<List<StaticPageViewModel>>(staticPages);
            return staticPagesVM;
        }

        public async Task<CreateStaticPageDto> Create(CreateStaticPageDto dto)
        {
            var staticPage = _mapper.Map<StaticPage>(dto);
            await _context.StaticPages.AddAsync(staticPage);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<UpdateStaticPageDto> Update(UpdateStaticPageDto dto)
        {
            var staticPage = await _context.StaticPages.SingleOrDefaultAsync(x => x.Id == dto.Id);

            if (staticPage == null)
                throw new ArgumentException("Item Not Found");
            else
            {

                var updatedStaticPage = _mapper.Map(dto, staticPage);
                var updatedStaticPageVM = _mapper.Map<StaticPage, UpdateStaticPageDto>(staticPage, dto);
                _context.StaticPages.Update(updatedStaticPage);
                await _context.SaveChangesAsync();
                return updatedStaticPageVM;

            }
           
        }

        public async Task<bool> Delete(int id)
        {
            var staticPage = await _context.StaticPages.FindAsync(id);
            if (staticPage == null)
                return false;
            else
            {
                _context.StaticPages.Remove(staticPage);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

    }
}
