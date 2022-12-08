using AutoMapper;
using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class BookSuggestionRepository : IBookSuggestionRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookSuggestionRepository(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<BookSuggestionViewModel>> GetAll()
        {
            var bookSuggestions = await _context.BookSuggestions.ToListAsync();
            var bookSuggestionsVM = _mapper.Map<List<BookSuggestionViewModel>>(bookSuggestions);
            return bookSuggestionsVM;
        }

        public async Task<CreateBookSuggestionDto> Create(CreateBookSuggestionDto dto)
        {
            var bookSuggestion = _mapper.Map<BookSuggestion>(dto);
            await _context.BookSuggestions.AddAsync(bookSuggestion);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<UpdateBookSuggestionDto> Update(UpdateBookSuggestionDto dto)
        {
            var bookSuggestions = await _context.BookSuggestions.SingleOrDefaultAsync(x => x.Id == dto.Id);

            if (bookSuggestions == null)
                throw new ArgumentException("Item Not Found");
            else
            {

                var updatedbookSuggestions = _mapper.Map(dto, bookSuggestions);
                var updatedbookSuggestionsVM = _mapper.Map<BookSuggestion, UpdateBookSuggestionDto>(bookSuggestions, dto);
                _context.BookSuggestions.Update(updatedbookSuggestions);
                await _context.SaveChangesAsync();
                return updatedbookSuggestionsVM;

            }
           
        }

        public async Task<bool> Delete(int id)
        {
            var bookSuggestions = await _context.BookSuggestions.FindAsync(id);
            if (bookSuggestions == null)
                return false;
            else
            {
                _context.BookSuggestions.Remove(bookSuggestions);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

    }
}
