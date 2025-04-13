using System;
using Core.DTOs.Category;
using Core.Entities;
using Core.Mappings;
using NuGet.Frameworks;

namespace Core.Tests.Mappings.CategoryMappings;

public class ToListDtoMethodTests
{
    [Fact]
    public void ToListDto_CanMapCategoryListDto_WhenProvidedValidCategoryEntity()
    {
        // Arrange
        Category category = new()
        {
            Id = 1,
            Name = "cat1"
        };

        // Act
        var listDto = category.ToListDto();

        // Assert
        Assert.Equal(1, listDto.Id);
        Assert.Equal("cat1", listDto.Name);
        Assert.Equal(new List<CategoryDto>(), listDto.SubCategories);
        Assert.Null(listDto.ParentCategoryId);
    }
}
