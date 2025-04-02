using Core.DTOs.Category;
using Core.Entities;
using Core.Entities.Enums;

namespace Core.Mappings;

public static class CategoryMappings
{
    public static CategoryDto ToDto(this Category category)
    {
        if (category == null) return null!;

        return new CategoryDto(
            category.Id,
            category.Name
        );
    }

    public static CategoryListDto ToListDto(this Category category)
    {
        if (category == null) return null!;

        return new CategoryListDto(
            category.Id,
            category.Name,
            category.ParentCategoryId,
            category.SubCategories?.Select(x => x.ToDto()).ToList() ?? new List<CategoryDto>()
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
