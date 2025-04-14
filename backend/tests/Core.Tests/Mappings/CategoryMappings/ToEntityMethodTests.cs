using System;
using Core.DTOs.Category;
using Core.Entities;
using Core.Mappings;

namespace Core.Tests.Mappings.CategoryMappings;

public class ToEntityMethodTests
{

    [Fact]
    public void ToEntity_CanMapToEntityWithoutParent_WhenProvidedValidCreateCategoryDtoWithoutParentId()
    {
        // Arrange
        CreateCategoryDto createCategoryDto = new()
        {
            Name = "cat",
            Description = "desc"
        };

        // Act
        Category category = createCategoryDto.ToEntity();

        // Assert
        Assert.NotNull(category);
        Assert.Equal("cat", category.Name);
        Assert.Equal("desc", category.Description);
        Assert.Null(category.ParentCategoryId);
    }

    [Fact]
    public void ToEntity_CanMapToEntityWithParentId_WhenProvidedValidCreateCategoryDtoWithParentId()
    {
        // Arrange
        CreateCategoryDto createCategoryDto = new()
        {
            Name = "cat",
            Description = "desc",
            ParentCategoryId = 1
        };

        // Act
        Category category = createCategoryDto.ToEntity();

        // Assert
        Assert.NotNull(category);
        Assert.Equal("cat", category.Name);
        Assert.Equal("desc", category.Description);
        Assert.NotNull(category.ParentCategoryId);
        Assert.Equal(1, category.ParentCategoryId);
    }

    [Fact]
    public void ToEntity_ThrowsArgumentNullException_WhenProvidedNullCreateCategoryDto()
    {
        // Arrange
        CreateCategoryDto createCategoryDto = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => createCategoryDto.ToEntity());
    }
}
