using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/zones")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneRepository _zoneRepository;
        public ZoneController(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateZoneDto input)
        {
            var author = await _zoneRepository.Create(input);
            return Ok(author);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateZoneDto input)
        {
            var zone = await _zoneRepository.Update(input);
            return Ok(zone);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? serachKey)
        {
            var zones = await _zoneRepository.GetAll(serachKey);
            return Ok(zones);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result = await _zoneRepository.Delete(id);
            return Ok(result);
        }

    }
}
