using ECommerceApp.Domain.Entities;
using ECommerceApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryRepository _categoryService;

        public CategoriesController(CategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            var categories = await _categoryService.GetAsync();
            return Ok(categories);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Category>> Get(string id)
        {
            var category = await _categoryService.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post(Category category)
        {
            await _categoryService.CreateAsync(category);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, Category category)
        {
            var categoryFromDb = await _categoryService.GetAsync(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            category.Id = categoryFromDb.Id;
            await _categoryService.UpdateAsync(id, category);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await _categoryService.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            await _categoryService.RemoveAsync(id);
            return NoContent();
        }


    }
}
