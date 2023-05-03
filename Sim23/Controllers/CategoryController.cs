using BLL.Helpers;
using BLL.Services.Interfaces;
using BLL.ViewModels.Category;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace Sim23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _categoryService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryCreateVM model)
        {
            var result = await _categoryService.CreateCategoryAsync(model);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put([FromBody] CategoryUpdateVM model)
        {
            var res = await _categoryService.UpdateCategoryAsync(model);
            if(res == null)
            {
                return BadRequest();
            }
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _categoryService.DeleteCategoryAsync(id);
            if(res)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
