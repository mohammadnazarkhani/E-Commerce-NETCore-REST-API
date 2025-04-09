using System;
using Core.DTOs.Category;
using Core.Entities;
using Core.Mappings;

namespace Core.Tests.Mappings;

public class CategoryMappingsTests
{
    [Fact]
    public void ToDto_CanMappCategoryToDto_WhenNotNullCategroyProvided()
    {
        // Arrange
        Category category = new Category()
        {
            Id = 1,
            Name = "Name"
        };

        // Act
        CategoryDto dto = category.ToDto();

        // Assert
        Assert.NotNull(dto);
        Assert.Equal(1, dto.Id);
        Assert.Equal("Name", dto.Name);
        // Assert Category obj not modified
        Assert.Equal(1, category.Id);
        Assert.Equal("Name", category.Name);
    }
}
