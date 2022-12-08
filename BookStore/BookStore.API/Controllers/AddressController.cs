using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/addresss")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressDto input)
        {
            var address = await _addressRepository.Create(input);
            return Ok(address);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateAddressDto input)
        {
            var address = await _addressRepository.Update(input);
            return Ok(address);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var address = await _addressRepository.GetAll();
            return Ok(address);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result = await _addressRepository.Delete(id);
            return Ok(result);
        }

    }
}
