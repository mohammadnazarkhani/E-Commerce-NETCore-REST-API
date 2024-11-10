using TondForoosh.Api.Dtos;
using TondForoosh.Api.Dtos.Category;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Mapping
{
    public static class CategoryMapping
    {
        // Extension method to map CreateCategoryDto to ProductCategory entity
        public static ProductCategory ToEntity(this CreateCategoryDto createCategoryDto)
        {
            return new ProductCategory
            {
                Title = createCategoryDto.Title
            };
        }

        // Extension method to map CategoryDto to ProductCategory entity for Update
        public static ProductCategory ToEntity(this UpdateCategoryDto updateCategoryDto, ProductCategory existingCategory)
        {
            existingCategory.Title = updateCategoryDto.Title;
            return existingCategory;
        }

        // Extension method to map ProductCategory entity to CategoryDto
        public static CategoryDto ToDto(this ProductCategory productCategory)
        {
            return new CategoryDto(
                productCategory.Id,
                productCategory.Title
            );
        }
    }
}
