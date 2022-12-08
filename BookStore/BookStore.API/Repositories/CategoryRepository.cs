using AutoMapper;
using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interface;
using BookStore.API.Models;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<CategoryViewModel>> GetAll(string? serachKey)
        {
            var categories = await _context.Categories.Where(x => x.Name.Contains(serachKey)
            || string.IsNullOrEmpty(serachKey)).Select(x => new CategoryViewModel()
            {   Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
            return categories;
        }

        public async Task<CreateCategoryDto> Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<UpdateCategoryDto> Update(UpdateCategoryDto dto)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == dto.Id);

            if (category == null)
                throw new ArgumentException("Item Not Found");
            else
            {

                var updatedCategory = _mapper.Map(dto, category);
                var updatedcategory = _mapper.Map<Category, UpdateCategoryDto>(category, dto);
                _context.Categories.Update(updatedCategory);
                await _context.SaveChangesAsync();
                return updatedcategory;

            }
           
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return false;
            else
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

    }
}
