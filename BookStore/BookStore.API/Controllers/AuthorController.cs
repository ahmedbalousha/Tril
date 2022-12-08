using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorDto input)
        {
            var author = await _authorRepository.Create(input);
            return Ok(author);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateAuthorDto input)
        {
            var author = await _authorRepository.Update(input);
            return Ok(author);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? serachKey)
        {
            var author = await _authorRepository.GetAll(serachKey);
            return Ok(author);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          var result =  await _authorRepository.Delete(id);
            return Ok(result);
        }

    }
}
