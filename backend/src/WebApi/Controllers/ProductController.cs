using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.DTOs;
using Infrastructure.Data;
using Core.Entities;
using Core.DTOs.Products.Requests;
using Core.DTOs.Products.Responses;
using AutoMapper;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ITondForooshRepository repository;
        private readonly IMapper _mapper;

        public ProductController(ITondForooshRepository repo, IMapper mapper)
        {
            repository = repo;
            _mapper = mapper;
            ControllerContext = new ControllerContext();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductListItemDto>>> GetAllProducts()
        {
            var products = await repository.Products.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ProductListItemDto>>(products));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDetailsDto>> GetProductById(long id)
        {
            var product = await repository.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(_mapper.Map<ProductDetailsDto>(product));
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
            if (createProductDto == null)
                return BadRequest();

            if (string.IsNullOrEmpty(createProductDto.Name))
            {
                ModelState.AddModelError("Name", "Name is required");
                return BadRequest(ModelState);
            }

            if (createProductDto.Price <= 0)
            {
                ModelState.AddModelError("Price", "Price must be greater than 0");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await repository.Categories.FirstOrDefaultAsync(c => c.Id == createProductDto.CategoryId);
            if (category == null)
            {
                ModelState.AddModelError("CategoryId", "Invalid category");
                return BadRequest(ModelState);
            }

            var product = _mapper.Map<Product>(createProductDto);
            var productId = await repository.AddAsync(product);

            return Ok(productId);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateProduct(long id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (updateProductDto == null)
                return BadRequest("DTO cannot be null");

            if (id != updateProductDto.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (updateProductDto.Price <= 0)
                return BadRequest("Price must be greater than 0");

            var product = await repository.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return NotFound();

            _mapper.Map(updateProductDto, product);
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