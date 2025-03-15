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
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await repository.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            Product? p = await repository.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (p == null)
                return NotFound();

            return Ok(p);
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

            var newProduct = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                ImageUrl = createProductDto.ImageUrl
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
            if (!string.IsNullOrEmpty(updateProductDto.Description))
                product.Description = updateProductDto.Description;
            if (updateProductDto.Price > 0)
                product.Price = updateProductDto.Price;
            if (!string.IsNullOrEmpty(updateProductDto.ImageUrl))
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

            repository.Delete(product);
            return NoContent();
        }
    }
}