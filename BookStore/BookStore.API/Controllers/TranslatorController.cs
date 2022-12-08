using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/translators")]
    [ApiController]
    public class TranslatorController : ControllerBase
    {
        private readonly ITranslatorRepository _translatorRepository;
        public TranslatorController(ITranslatorRepository translatorRepository)
        {
            _translatorRepository = translatorRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTranslatorDto input)
        {
            var translator = await _translatorRepository.Create(input);
            return Ok(translator);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateTranslatorDto input)
        {
            var translator = await _translatorRepository.Update(input);
            return Ok(translator);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? serachKey)
        {
            var translators = await _translatorRepository.GetAll(serachKey);
            return Ok(translators);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          var result =  await _translatorRepository.Delete(id);
            
            return Ok(result);
        }

    }
}
