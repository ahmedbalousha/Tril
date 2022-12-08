using AutoMapper;
using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Services;
using BookStore.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class BookReviewRepository : IBookReviewRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;


        public BookReviewRepository(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CreateBookReviewDto> Create(CreateBookReviewDto dto)
        {
            var rate = _mapper.Map<BookReview>(dto);
            await _context.BookReviews.AddAsync(rate);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<double> GetBookRating(int bookId)
        {
            var bookRatings = await _context.BookReviews
                .Where(x => x.BookId == bookId).ToListAsync();
            var bookRatingsVM = _mapper.Map<List<BookReviewViewModel>>(bookRatings);
            var rating = bookRatingsVM.Average(x => x.Rate);
            return rating;
        }
       
        public async Task<UpdateBookReviewDto> Update(UpdateBookReviewDto dto)
        {
            var bookReview = await _context.BookReviews.SingleOrDefaultAsync(x => x.Id == dto.Id);

            if (bookReview == null)
                throw new ArgumentException("Item Not Found");
            else
            {

                var updatedBookReview = _mapper.Map(dto, bookReview);
               
                var updatedBookReviewVM = _mapper.Map<BookReview, UpdateBookReviewDto>(bookReview, dto);
                _context.BookReviews.Update(updatedBookReview);
                await _context.SaveChangesAsync();
                return updatedBookReviewVM;

            }

        }

        public async Task<bool> Delete(int id)
        {
            var bookReviews = await _context.BookReviews.FindAsync(id);
            if (bookReviews == null)
                return false;
            else
            {
                _context.BookReviews.Remove(bookReviews);
                await _context.SaveChangesAsync();
                return true;
            }

        }
    }
}
