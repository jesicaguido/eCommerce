using Microsoft.AspNetCore.Mvc;
using ProductApplication.DTO;
using ProductApplication.Services;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    /// <summary>
    /// API controller exposing CRUD endpoints for Product entities.
    /// Uses the product service to encapsulate business logic and returns
    /// appropriate HTTP responses based on operation results.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Retrieves a product by its identifier.
        /// </summary>
        /// <param name="id">Identifier of the product.</param>
        /// <returns>200 OK with the product or 404 Not Found if it does not exist.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(result.Error);
            return Ok(result.Value);
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>200 OK with the collection of products.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();
            return Ok(result.Value);
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="request">DTO containing the values for the new product.</param>
        /// <returns>201 Created with the created product, or 400 Bad Request on validation errors.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto request)
        {
            var result = await _productService.CreateAsync(request);
            if (!result.IsSuccess)
                return BadRequest(result.Error);
            // return the location of the new resource
            return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">Identifier of the product to update.</param>
        /// <param name="request">DTO containing values to update.</param>
        /// <returns>200 OK with the updated product or 400/404 on error.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto request)
        {
            var result = await _productService.UpdateAsync(id, request);
            if (!result.IsSuccess)
                return BadRequest(result.Error);
            return Ok(result.Value);
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="id">Identifier of the product to delete.</param>
        /// <returns>204 No Content on success or 404 Not Found if the product does not exist.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (!result.IsSuccess)
                return NotFound(result.Error);
            return NoContent();
        }
    }
}