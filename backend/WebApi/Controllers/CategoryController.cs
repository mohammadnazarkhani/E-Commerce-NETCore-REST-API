using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.DTOs;
using Infrastructure.Data;
using Core.Entities;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ITondForooshRepository repository;

    public CategoryController(ITondForooshRepository repo)
    {
        repository = repo;
    }

    /// <summary>
    /// Gets all categories
    /// </summary>
    /// <returns>List of all categories</returns>
    /// <response code="200">Returns the list of categories</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        var categories = await repository.Categories.ToListAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        var category = await repository.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category == null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
    {
        if (createCategoryDto == null || !ModelState.IsValid)
            return BadRequest();

        var category = new Category { Name = createCategoryDto.Name };
        var categoryId = await repository.AddCategoryAsync(category);

        return Ok(categoryId);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
    {
        if (updateCategoryDto == null || !ModelState.IsValid)
            return BadRequest("Invalid Data");

        var category = await repository.Categories.FirstOrDefaultAsync(c => c.Id == updateCategoryDto.Id);
        if (category == null)
            return NotFound();

        if (!string.IsNullOrEmpty(updateCategoryDto.Name))
            category.Name = updateCategoryDto.Name;

        await repository.UpdateCategoryAsync(category);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        var category = await repository.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category == null)
            return NotFound();

        await repository.DeleteCategoryAsync(category);
        return NoContent();
    }
}
