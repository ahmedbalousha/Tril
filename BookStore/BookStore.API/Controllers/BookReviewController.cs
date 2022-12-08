using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/bookReviews")]
    [ApiController]
    public class BookReviewController : ControllerBase
    {
        private readonly IBookReviewRepository _bookReviewRepository;
        public BookReviewController(IBookReviewRepository bookReviewRepository)
        {
            _bookReviewRepository = bookReviewRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookReviewDto input)
        {
            var bookReview = await _bookReviewRepository.Create(input);
            return Ok(bookReview);

        }


        [HttpGet]
        public async Task<IActionResult> GetAll(int bookId)
        {
            var bookReview = await _bookReviewRepository.GetBookRating(bookId);
            return Ok(bookReview);

        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookReviewDto input)
        {
            var bookReview = await _bookReviewRepository.Update(input);
            return Ok(bookReview);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookReviewRepository.Delete(id);
            return Ok(result);
        }

    }
}
