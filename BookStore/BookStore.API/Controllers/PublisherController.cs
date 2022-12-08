using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/publishers")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;
        public PublisherController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreatePublisherDto input)
        {
            var publisher = await _publisherRepository.Create(input);
            return Ok(publisher);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdatePublisherDto input)
        {
            var publisher = await _publisherRepository.Update(input);
            return Ok(publisher);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? serachKey)
        {
            var publishers = await _publisherRepository.GetAll(serachKey);
            return Ok(publishers);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
         var result = await _publisherRepository.Delete(id);
            return Ok(result);
        }

    }
}
