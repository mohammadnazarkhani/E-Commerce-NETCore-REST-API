using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.DTOs.Categories.Requests;
using Core.DTOs.Categories.Responses;
using Infrastructure.Data;
using Core.Entities;
using AutoMapper;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ITondForooshRepository repository;
    private readonly IMapper _mapper;

    public CategoryController(ITondForooshRepository repo, IMapper mapper)
    {
        repository = repo;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        var categories = await repository.Categories.ToListAsync();
        return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryDto>> GetCategory(int id)
    {
        var category = await repository.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category == null)
            return NotFound();

        return Ok(_mapper.Map<CategoryDto>(category));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var category = _mapper.Map<Category>(createCategoryDto);
        var categoryId = await repository.AddCategoryAsync(category);

        return Ok(categoryId);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateCategory(long id, [FromBody] UpdateCategoryDto updateCategoryDto)
    {
        if (id != updateCategoryDto.Id)
            return BadRequest("ID mismatch");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var category = await repository.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category == null)
            return NotFound();

        _mapper.Map(updateCategoryDto, category);
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
