using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.DTOs;
using Infrastructure.Data;
using Core.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ITondForooshRepository repository;

        public ProductController(ITondForooshRepository repo)
        {
            repository = repo;
            ControllerContext = new ControllerContext();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await repository.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductById(long id)
        {
            Product? p = await repository.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (p == null)
                return NotFound();

            return Ok(p);
        }

        [HttpGet("category/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Product>> GerProductsByCategory(int categoryId)
        {
            var products = await repository.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

            if (products == null || !products.Any())
                return NotFound("No products found for the given category");

            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<long>> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            if (createProductDto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            // Verify that the category exists
            var category = await repository.Categories.FirstOrDefaultAsync(c => c.Id == createProductDto.CategoryId);
            if (category == null)
            {
                return BadRequest("Invalid category");
            }

            var newProduct = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                ImageUrl = createProductDto.ImageUrl,
                CategoryId = createProductDto.CategoryId
            };

            var productId = await repository.AddAsync(newProduct);

            return Ok(productId);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
        {
            if (updateProductDto == null || !ModelState.IsValid)
                return BadRequest("Invalid Data");

            var product = await repository.Products.FirstOrDefaultAsync(p => p.Id == updateProductDto.Id);
            if (product == null)
                return NotFound();

            // Update only provided values
            if (!string.IsNullOrEmpty(updateProductDto.Name))
                product.Name = updateProductDto.Name;
            if (updateProductDto.Description != null)
                product.Description = updateProductDto.Description;
            if (updateProductDto.Price > 0)
                product.Price = updateProductDto.Price;

            // Handle ImageUrl separately - allow null/empty to clear the URL
            product.ImageUrl = updateProductDto.ImageUrl;

            await repository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteProduct(long id)
        {
            var product = await repository.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return NotFound();

            await repository.DeleteAsync(product);
            return NoContent();
        }
    }
}