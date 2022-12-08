using AutoMapper;
using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorRepository(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<AuthorViewModel>> GetAll(string? serachKey)
        {
            var authors = await _context.Authors.Where(x => x.Name.Contains(serachKey)
            || string.IsNullOrEmpty(serachKey)).Select(x => new AuthorViewModel()
            {   Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
            return authors;
        }

        public async Task<CreateAuthorDto> Create(CreateAuthorDto dto)
        {
            var author = _mapper.Map<Author>(dto);
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<UpdateAuthorDto> Update(UpdateAuthorDto dto)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(x => x.Id == dto.Id);

            if (author == null)
                throw new ArgumentException("Item Not Found");
            else
            {

                var updatedAuthor = _mapper.Map(dto, author);
                var updatedAuthorVM = _mapper.Map<Author, UpdateAuthorDto>(author, dto);
                _context.Authors.Update(updatedAuthor);
                await _context.SaveChangesAsync();
                return updatedAuthorVM;

            }
           
        }

        public async Task<bool> Delete(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return false;
            else
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

    }
}
