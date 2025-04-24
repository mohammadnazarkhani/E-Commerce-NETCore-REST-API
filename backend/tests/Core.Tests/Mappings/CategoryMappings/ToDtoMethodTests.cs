using System;
using Core.DTOs.Category;
using Core.Entities;
using Core.Mappings;

namespace Core.Tests.Mappings.CategoryMappings;

public class ToDtoMethodTests
{
    [Fact]
    public void ToDto_ShouldReturnCategoryDto_WhenCategoryIsValid()
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

    [Fact]
    public void ToDto_ShouldThrowArgumentException_WhenCategoryNameIsNull()
    {
        // Arrange
        Category category = new Category()
        {
            Id = 1,
            Name = null!
        };

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => category.ToDto());
    }

    [Fact]
    public void ToDto_ShouldThrowArgumentNullException_WhenCategoryIsNull()
    {
        // Arrange
        Category category = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => category.ToDto());
    }
}
