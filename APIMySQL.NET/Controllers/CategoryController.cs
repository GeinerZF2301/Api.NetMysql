using APIMySQL.NET.Data.Repositories;
using APIMySQL.NET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMySQL.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
           return Ok(await _categoryRepository.GetAllCategories());
           
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(await _categoryRepository.GetCategoryById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
                if (category == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var created = await _categoryRepository.CreateCategory(category);
                return Created("La categoria fue creada exitosamente", created);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            
            if (category == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _categoryRepository.UpdateCategory(category);
            return Ok("La categoria fue actualizada exitosamente");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
            return NoContent();
        }

    }
}
