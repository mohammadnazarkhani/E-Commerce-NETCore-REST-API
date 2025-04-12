using Core.DTOs.Category;
using Core.Entities;
using Core.Entities.Enums;

namespace Core.Mappings;

/// <summary>
/// Provides mappin extension methods between category entity and category dtos
/// </summary>
public static class CategoryMappings
{
    /// <summary>
    /// Maps Category entity to CategoryDto 
    /// </summary>
    /// <param name="category">Category entity to be mapped.</param>
    /// <returns>Returns a CategoryDto with mapped id and name properties from Category entity.</returns>
    public static CategoryDto ToDto(this Category category)
    {
        if (category == null)
            throw new ArgumentNullException(nameof(category), "Category cannot be null");


        if (String.IsNullOrWhiteSpace(category.Name))
            throw new ArgumentException("Category name cannot be null or empty", nameof(category));

        return new CategoryDto(
            category.Id,
            category.Name
        );
    }

    /// <summary>
    /// Mapping extension method for mapping Category entity to CategoryListDto
    /// </summary>
    /// <param name="category">Category entity to be mapped.</param>
    /// <returns>Returns a CategoryListDto with mapped id, name and ParentCategoryId and Subcategories list if null null properties from Category entity.</returns>
    public static CategoryListDto ToListDto(this Category category)
    {
        if (category == null) return null!;

        return new CategoryListDto(
            category.Id,
            category.Name,
            category?.ParentCategoryId,
            category?.SubCategories.Select(x => x.ToDto()).ToList() ?? new List<CategoryDto>()
        );
    }

    public static Category ToEntity(this CreateCategoryDto createCategoryDto)
    {
        if (createCategoryDto == null) return null!;

        return new Category
        {
            Name = createCategoryDto.Name,
            Description = createCategoryDto.Description,
            ParentCategoryId = createCategoryDto.ParentCategoryId
        };
    }

    public static void UpdateFromDto(this Category category, UpdateCategoryDto updateCategoryDto)
    {
        if (updateCategoryDto == null || category == null) return;

        if (updateCategoryDto.Name != null)
            category.Name = updateCategoryDto.Name;

        category.Description = updateCategoryDto.Description;
        category.ParentCategoryId = updateCategoryDto.ParentCategoryId;
        category.SetStatus(EntityStatus.Modified);
    }
}
