using eCommerce.SharedLibrary.DTOs;
using eCommerce.SharedLibrary.DTOs.Category;
using eCommerce.SharedLibrary.DTOs.Product;
using eCommerce.Application.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// Controllers: Presentation Layer

// Controllers are key components in the MVC (Model-View-Controller) architectural pattern. 
// They act as the middlemen, handling user input and interactions. 
// Think of them as traffic directors, ensuring data flows smoothly between the user interface (the View) and the application’s core logic (the Model).

namespace eCommerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // https://localhost:7025/api/category/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<GetCategory>>> GetAll()
        {
            var results = await categoryService.GetCategories();
            if (results.Count() > 0)
                return Ok(results);
            return NotFound();
        }

        [HttpGet("single/{id}")]
        public async Task<ActionResult<GetCategory>> GetSingleCategory(int id)
        {
            var result = await categoryService.GetCategoryById(id);
            if (result is null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse>> AddCategory(CreateCategory category)

        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await categoryService.AddCategory(category);
            if (!result.Success)
                return BadRequest();
            else
                return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse>> UpdateCategory(UpdateCategory category)

        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await categoryService.UpdateCategory(category);
            if (!result.Success)
                return BadRequest();
            else
                return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ServiceResponse>> DeleteCategory(int id)
        {
            var result = await categoryService.DeleteCategory(id);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
