using System;
using Core.DTOs.Category;
using Core.Entities;
using Core.Mappings;
using NuGet.Frameworks;

namespace Core.Tests.Mappings.CategoryMappings;

public class ToListDtoMethodTests
{
    [Fact]
    public void ToListDto_CanMapCategoryListDto_WhenProvidedValidCategoryEntityWithoutSubAndParentCategories()
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

    [Fact]
    public void ToListDto_CanMapCategoryListDtoWithSubAndParentCategories_WhenProvidedValidCategoryEntityWithSubAndParentCategories()
    {
        // Arrange
        Category parentCategory = new()
        {
            Id = 1,
            Name = "ParentCategory"
        };
        Category subCategory1 = new()
        {
            Id = 2,
            Name = "sub1"
        };
        Category subCategory2 = new()
        {
            Id = 3,
            Name = "sub2"
        };

        // Arrange - create target Categoriy
        List<Category> subCategories =
        [
            subCategory1,
            subCategory2
        ];
        Category targetCategory = new()
        {
            Id = 4,
            Name = "cat",
            ParentCategory = parentCategory,
            ParentCategoryId = parentCategory.Id,
            SubCategories = subCategories
        };

        // Act
        CategoryListDto categoryListDto = targetCategory.ToListDto();

        // Assert
        Assert.Equal(4, categoryListDto.Id);
        Assert.Equal("cat", categoryListDto.Name);
        Assert.Equal(parentCategory.Id, categoryListDto.ParentCategoryId);
        List<CategoryDto> subAssertionCategories = subCategories.Select(x => x.ToDto()).ToList<CategoryDto>();
        Assert.Equal(subAssertionCategories, categoryListDto.SubCategories);
    }

    [Fact]
    public void ToListDto_TrhowsArgumentNullExceptiuon_WhenProvidedNullCategoryObj()
    {
        // Arrange 
        Category category = null!;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => category.ToDto());
    }

    [Fact]
    public void ToListDto_ThrowsArgumentException_WhenNullNamePropertyProvided()
    {
        // Arrange
        Category category = new Category()
        {
            Id = 1,
            Name = null!
        };

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => category.ToListDto());
    }
}
