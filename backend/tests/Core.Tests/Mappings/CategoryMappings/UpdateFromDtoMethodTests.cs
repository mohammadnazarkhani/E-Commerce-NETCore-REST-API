using System;
using Core.DTOs.Category;
using Core.Entities;
using Core.Entities.Enums;
using Core.Mappings;
using NuGet.Frameworks;

namespace Core.Tests.Mappings.CategoryMappings;

public class UpdateFromDtoMethodTests
{
    private Category _sharedCategory;
    private Category _sharedParentCategory;
    private UpdateCategoryDto _sharedUpdateDto;

    public UpdateFromDtoMethodTests()
    {
        _sharedParentCategory = new Category()
        {
            Id = 1,
            Name = "cat1",
            Description = "description"
        };

        _sharedCategory = new Category()
        {
            Id = 2,
            Name = "cat2",
            Description = "description"
        };

        _sharedUpdateDto = new UpdateCategoryDto("update", "update", _sharedParentCategory.Id);
    }

    [Fact]
    public void UpdateFromDto_ShouldThrowArgumentNullException_WhenCategoryIsNull()
    {
        // Arrange - create null category
        Category category = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => category.UpdateFromDto(_sharedUpdateDto));
    }

    [Fact]
    public void UpdateFromDto_ShouldThrowArgumentNullException_WhenUpdateDtoIsNull()
    {
        // Arrange
        UpdateCategoryDto updateCategoryDto = null!;

        // Act & Arrange
        var exception = Assert.Throws<ArgumentNullException>(() => _sharedCategory.UpdateFromDto(updateCategoryDto));
    }

    [Fact]
    public void UpdateFromDto_ShouldPreserveOriginalName_WhenUpdateDtoNameIsNull()
    {
        // Arrange
        string nullName = null!;
        UpdateCategoryDto updateCategoryDto = new UpdateCategoryDto(nullName, "description", 0);

        // Act
        _sharedCategory.UpdateFromDto(updateCategoryDto);

        // Assert
        Assert.NotNull(_sharedCategory);
        Assert.Equal("cat2", _sharedCategory.Name);
    }

    [Fact]
    public void UpdateFromDto_ShouldPreserveOriginalName_WhenUpdateDtoNameIsEmpty()
    {
        // Arrange
        string emptyName = string.Empty;
        UpdateCategoryDto updateCategoryDto = new UpdateCategoryDto(emptyName, "description", 0);


        // Act
        _sharedCategory.UpdateFromDto(updateCategoryDto);

        // Assert
        Assert.NotNull(_sharedCategory);
        Assert.Equal("cat2", _sharedCategory.Name);
    }

    [Fact]
    public void UpdateFromDto_ShouldPreserveOriginalName_WhenUpdateDtoNameIsWhitespace()
    {
        // Arrange
        string whiteSpaceName = " ";
        UpdateCategoryDto updateCategoryDto = new UpdateCategoryDto(whiteSpaceName, "description", 0);


        // Act
        _sharedCategory.UpdateFromDto(updateCategoryDto);

        // Assert
        Assert.NotNull(_sharedCategory);
        Assert.Equal("cat2", _sharedCategory.Name);
    }

    [Fact]
    public void UpdateFromDto_ShouldUpdateAllProperties_WhenUpdateDtoIsValid()
    {
        // Act
        _sharedCategory.UpdateFromDto(_sharedUpdateDto);

        // Assert
        Assert.NotNull(_sharedCategory);
        Assert.Equal(2, _sharedCategory.Id);
        Assert.Equal("update", _sharedCategory.Name);
        Assert.Equal("update", _sharedCategory.Description);
        Assert.Equal(1, _sharedCategory.ParentCategoryId);
        Assert.Equal(EntityStatus.Modified, _sharedCategory.Status);
    }
}
