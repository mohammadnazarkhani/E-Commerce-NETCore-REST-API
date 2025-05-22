using System;
using Core.DTOs.Category;
using Core.Entities;
using Core.Mappings;

namespace Core.Tests.Mappings.CategoryMappings;

public class ToEntityMethodTests
{

    [Fact]
    public void ToEntity_ShouldCreateCategoryWithoutParent_WhenParentIdIsNotProvided()
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
    public void ToEntity_ShouldCreateCategoryWithParent_WhenParentIdIsProvided()
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
    public void ToEntity_ShouldThrowArgumentNullException_WhenDtoIsNull()
    {
        // Arrange
        CreateCategoryDto createCategoryDto = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => createCategoryDto.ToEntity());
    }

    [Fact]
    public void ToEntity_ShouldThrowArgumentException_WhenNameIsNull()
    {
        // Arrange
        CreateCategoryDto createCategoryDto = new()
        {
            Name = null!
        };

        // Act & Arrange
        var exception = Assert.Throws<ArgumentException>(() => createCategoryDto.ToEntity());
    }
}
