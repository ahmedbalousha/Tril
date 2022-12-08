using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/bookSuggestions")]
    [ApiController]
    public class BookSuggestionController : ControllerBase
    {
        private readonly IBookSuggestionRepository _bookSuggestionRepository;
        public BookSuggestionController(IBookSuggestionRepository bookSuggestionRepository)
        {
            _bookSuggestionRepository = bookSuggestionRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookSuggestionDto input)
        {
            var bookSuggestion = await _bookSuggestionRepository.Create(input);
            return Ok(bookSuggestion);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateBookSuggestionDto input)
        {
            var bookSuggestion = await _bookSuggestionRepository.Update(input);
            return Ok(bookSuggestion);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookSuggestion = await _bookSuggestionRepository.GetAll();
            return Ok(bookSuggestion);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          var result =  await _bookSuggestionRepository.Delete(id);
            return Ok(result);
        }

    }
}
