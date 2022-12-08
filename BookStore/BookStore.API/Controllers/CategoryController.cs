using BookStore.API.DTOs;
using BookStore.API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto input)
        {
            var category = await _categoryRepository.Create(input);
            return Ok(category);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateCategoryDto input)
        {
            var category = await _categoryRepository.Update(input);
            return Ok(category);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? serachKey)
        {
            var category = await _categoryRepository.GetAll(serachKey);
            return Ok(category);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var result = await _categoryRepository.Delete(id);
            return Ok(result);
        }

    }
}
