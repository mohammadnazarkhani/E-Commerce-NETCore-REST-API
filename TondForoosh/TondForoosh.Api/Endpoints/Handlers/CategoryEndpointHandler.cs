using TondForoosh.Api.Data;
using TondForoosh.Api.Dtos;
using TondForoosh.Api.Entities;
using TondForoosh.Api.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace TondForoosh.Api.Endpoints.Handlers
{
    public class CategoryEndpointHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryEndpointHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all categories
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            return new OkObjectResult(categories.Select(c => c.ToDto()));
        }

        // Get a specific category by ID
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
                return new NotFoundResult();

            return new OkObjectResult(category.ToDto());
        }

        // Create a new category
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = createCategoryDto.ToEntity();

            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category.ToDto());
        }

        // Update an existing category
        public async Task<IActionResult> UpdateCategoryAsync(int id, CreateCategoryDto createCategoryDto)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
                return new NotFoundResult();

            category.Title = createCategoryDto.Title;
            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return new OkObjectResult(category.ToDto());
        }

        // Delete an existing category
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var categoryExists = await _unitOfWork.CategoryRepository.ExistsAsync(id);
            if (!categoryExists)
                return new NotFoundResult();

            await _unitOfWork.CategoryRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
