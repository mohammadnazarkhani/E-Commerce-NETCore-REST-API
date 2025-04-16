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
    public void UpdateFromDto_ThrowsArgumentNullException_WhenProvidedWithNullCategoryObj()
    {
        // Arrange - create null category
        Category category = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => category.UpdateFromDto(_sharedUpdateDto));
    }

    [Fact]
    public void UpdateFromDto_ThrowsArgumentNullException_WhenProvidedWithNullUpdateCategoryDtoObj()
    {
        // Arrange
        UpdateCategoryDto updateCategoryDto = null!;

        // Act & Arrange
        var exception = Assert.Throws<ArgumentNullException>(() => _sharedCategory.UpdateFromDto(updateCategoryDto));
    }

    [Fact]
    public void UpdateFromDto_DoesNotUpdateName_WhenProvidedWith_Null_UpdateCategoryDtoNameProperty()
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
    public void UpdateFromDto_DoesNotUpdateName_WhenProvidedWith_Empty_UpdateCategoryDtoNameProperty()
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
    public void UpdateFromDto_DoesNotUpdateName_WhenProvidedWith_WhiteSpace_UpdateCategoryDtoNameProperty()
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
    public void UpdateFromDto_CanUpdateCategory_WhenProvidedValidUpdateDto()
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
