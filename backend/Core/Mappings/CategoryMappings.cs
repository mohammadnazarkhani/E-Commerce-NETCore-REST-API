using System;
using System.Collections.ObjectModel;
using System.Linq;
using Core.DTOs.Category;
using Core.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core.Mappings;

public static class CategoryMappings
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto(
            category.Id,
            category.Name
        );
    }

    public static CategoryListDto ToListDto(this Category category)
    {
        return new CategoryListDto(
            category.Id,
            category.Name,
            category.ParentCategoryId,
            category.SubCategories?.Select(x => x.ToDto()).ToList() ?? new List<CategoryDto>()
        );
    }

    public static Category ToEntity(this CreateCategoryDto createCategoryDto)
    {
        return new Category
        {
            Name = createCategoryDto.Name,
            Description = createCategoryDto.Description,
            ParentCategoryId = createCategoryDto.ParentCategoryId
        };
    }

    public static Category ToEntity(this UpdateCategoryDto updateCategoryDto)
    {
        return new Category
        {
            Name = updateCategoryDto.Name ?? string.Empty,
            Description = updateCategoryDto.Description,
            ParentCategoryId = updateCategoryDto.ParentCategoryId,
        };
    }
}
