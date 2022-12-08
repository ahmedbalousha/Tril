using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/contantUss")]
    [ApiController]
    public class ContantUsController : ControllerBase
    {
        private readonly IContantUsRepository _contantUsRepository;
        public ContantUsController(IContantUsRepository contantUsRepository)
        {
            _contantUsRepository = contantUsRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContantUsDto input)
        {
            var contantUs = await _contantUsRepository.Create(input);
            return Ok(contantUs);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateContantUsDto input)
        {
            var contantUs = await _contantUsRepository.Update(input);
            return Ok(contantUs);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contantUs = await _contantUsRepository.GetAll();
            return Ok(contantUs);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result = await _contantUsRepository.Delete(id);
            return Ok(result);
        }

    }
}
