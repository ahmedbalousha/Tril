using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticPageController : ControllerBase
    {
        private readonly IStaticPageRepository _staticPageRepository;
        public StaticPageController(IStaticPageRepository staticPageRepository)
        {
            _staticPageRepository = staticPageRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStaticPageDto input)
        {
            var staticPage = await _staticPageRepository.Create(input);
            return Ok(staticPage);

        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateStaticPageDto input)
        {
            var staticPage = await _staticPageRepository.Update(input);
            return Ok(staticPage);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staticPage = await _staticPageRepository.GetAll();
            return Ok(staticPage);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _staticPageRepository.Delete(id);
            return Ok(result);
        }

    }
}
