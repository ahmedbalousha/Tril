using BookStore.API.DTOs;
using BookStore.API.Interface;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAll();
            return Ok(books);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByCategory(int id)
        {
            var books = await _bookRepository.GetAllByCategory(id);
            return Ok(books);

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateBookDto input)
        {
            var file = Request.Form.Files[0];
            var book = await _bookRepository.Create(input);
            return Ok(book);

        }
        [HttpPut]
        public async Task<IActionResult> Update ([FromForm] UpdateBookDto input)
        {
            var updatedbook = await _bookRepository.Update(input);
            return Ok(updatedbook);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookRepository.Delete(id);
            return Ok(book);
        }

    }
}
