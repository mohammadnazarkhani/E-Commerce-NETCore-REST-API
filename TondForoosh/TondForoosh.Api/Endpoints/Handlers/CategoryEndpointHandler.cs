using TondForoosh.Api.Data;
using TondForoosh.Api.Dtos;
using TondForoosh.Api.Entities;
using TondForoosh.Api.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TondForoosh.Api.Dtos.Category;

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

        // Create a new category (Admin only)
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = createCategoryDto.ToEntity();
            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return new CreatedResult($"/categories/{category.Id}", category.ToDto());
        }

        // Update an existing category (Admin only)
        public async Task<IActionResult> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
                return new NotFoundResult();

            category.UpdateEntity(updateCategoryDto);
            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return new OkObjectResult(category.ToDto());
        }

        // Delete an existing category (Admin only)
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
                return new NotFoundResult();

            await _unitOfWork.CategoryRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
