using DPA.Store.DOMAIN.Core.DTO;
using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Store.API.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromQuery] bool includeProducts)
        {
            if (includeProducts)
                return Ok(await _categoryService.GetCategoryProductsById(id));

            return Ok(await _categoryService.GetCategoryById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDescriptioDTO categoryDTO)
        {
            int id = await _categoryService.Insert(categoryDTO);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryListDTO category)
        {
            bool result = await _categoryService.Update(category);
            return result?Ok(result):BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _categoryService.Delete(id);
            return result ? Ok(result) : BadRequest();
        }

    }
}
