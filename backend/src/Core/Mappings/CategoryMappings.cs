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
    /// <exception cref="ArgumentNullException">
    /// Thrown when:
    /// The category parameter is null
    /// Message: "Category cannot be null
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when:
    /// - The category.Name is null or consists only of whitespace characters
    /// - Message: "Category name cannot be null or empty"
    /// </exception>
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
    /// <returns>Returns a CategoryListDto with mapped id, name, ParentCategoryId and Subcategories list from Category entity.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when:
    /// - The category parameter is null
    /// - Message: "Category cannot be null"
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when:
    /// - The category.Name is null or consists only of whitespace characters
    /// - Message: "Category name cannot be null or empty"
    /// </exception>
    public static CategoryListDto ToListDto(this Category category)
    {
        if (category == null)
            throw new ArgumentNullException(nameof(category), "Category cannot be null");

        if (String.IsNullOrWhiteSpace(category.Name))
            throw new ArgumentException("Category name cannot be null or empty", nameof(category));

        return new CategoryListDto(
            category.Id,
            category.Name,
            category.ParentCategoryId,
            category.SubCategories?.Select(x => x.ToDto()).ToList() ?? new List<CategoryDto>()
        );
    }

    /// <summary>
    /// Maps CreateCategoryDto to Category entity
    /// </summary>
    /// <param name="createCategoryDto">The DTO to map from</param>
    /// <returns>A new Category entity</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when:
    /// - The createCategoryDto parameter is null
    /// - Message: "CreateCategoryDto cannot be null"
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when:
    /// - The Name property is null or empty
    /// - Message: "Category name cannot be null or empty"
    /// </exception>
    public static Category ToEntity(this CreateCategoryDto createCategoryDto)
    {
        if (createCategoryDto == null)
            throw new ArgumentNullException(nameof(createCategoryDto), "CreateCategoryDto cannot be null");

        if (String.IsNullOrWhiteSpace(createCategoryDto.Name))
            throw new ArgumentException("Category name cannot be null or empty", nameof(createCategoryDto));

        return new Category
        {
            Name = createCategoryDto.Name,
            Description = createCategoryDto.Description,
            ParentCategoryId = createCategoryDto.ParentCategoryId
        };
    }

    /// <summary>
    /// Updates a Category entity from an UpdateCategoryDto
    /// </summary>
    /// <param name="category">The category entity to update</param>
    /// <param name="updateCategoryDto">The DTO containing update information</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when:
    /// - The category parameter is null
    /// - The updateCategoryDto parameter is null
    /// - Messages: "Category cannot be null" or "UpdateCategoryDto cannot be null"
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when:
    /// - The Name property in updateCategoryDto is empty or whitespace
    /// - Message: "Category name cannot be null or empty"
    /// </exception>
    public static void UpdateFromDto(this Category category, UpdateCategoryDto updateCategoryDto)
    {
        if (category == null)
            throw new ArgumentNullException(nameof(category), "Category cannot be null");

        if (updateCategoryDto == null)
            throw new ArgumentNullException(nameof(updateCategoryDto), "UpdateCategoryDto cannot be null");

        if (String.IsNullOrWhiteSpace(updateCategoryDto.Name))
            throw new ArgumentException("Category name cannot be null or empty", nameof(updateCategoryDto));

        if (updateCategoryDto.Name != null)
            category.Name = updateCategoryDto.Name;

        category.Description = updateCategoryDto.Description;
        category.ParentCategoryId = updateCategoryDto.ParentCategoryId;
        category.SetStatus(EntityStatus.Modified);
    }
}
