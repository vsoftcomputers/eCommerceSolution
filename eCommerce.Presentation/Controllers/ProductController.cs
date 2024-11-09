using eCommerce.SharedLibrary.DTOs;
using eCommerce.SharedLibrary.DTOs.Product;
using eCommerce.Application.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// Controllers: Presentation Layer

// Controllers are key components in the MVC (Model-View-Controller) architectural pattern. 
// They act as the middlemen, handling user input and interactions. 
// Think of them as traffic directors, ensuring data flows smoothly between the user interface (the View) and the application’s core logic (the Model).

namespace eCommerce.Presentation.Controllers
{
    // https://localhost:7025/api/product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // https://localhost:7025/api/product/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<GetProduct>>> GetAll()
        {
            var results = await productService.GetProducts();
            if (results.Count() > 0)
                return Ok(results);
            return NotFound();
        }

        [HttpGet("single/{id}")]
        public async Task<ActionResult<GetProduct>> GetSingleProduct(int id)
        {
            var result = await productService.GetProductById(id);
            if (result is null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse>> AddProduct(CreateProduct product)
        
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await productService.AddProduct(product);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse>> UpdateProduct(UpdateProduct product)

        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await productService.UpdateProduct(product);
            if (!result.Success)
                return BadRequest();
            else
                return Ok(result);
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ServiceResponse>> DeleteProduct(int id)
        {
            var result = await productService.DeleteProduct(id);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
