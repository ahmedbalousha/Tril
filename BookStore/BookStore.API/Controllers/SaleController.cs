using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _saleRepository.GetAll();
            return Ok(sales);

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSaleDto input)
        {
            var sale = await _saleRepository.Create(input);
            return Ok(sale);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _saleRepository.Delete(id);
            return Ok(result);
        }
    }
}
