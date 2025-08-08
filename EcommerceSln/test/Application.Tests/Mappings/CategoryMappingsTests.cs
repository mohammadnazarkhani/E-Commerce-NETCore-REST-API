using Application.DTOs;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;

namespace Application.Tests.Mappings;

public class CategoryMappingsTests
{
    private readonly IMapper _mapper;
    
    public CategoryMappingsTests()
    {
        var mapperConfig = new MapperConfiguration(
            cfg => cfg.AddProfile<CategoryMappings>()
        );
        
        _mapper = mapperConfig.CreateMapper();
    }
    
    [Fact]
    public void Map_Category_To_CategoryDto_Should_Map_Correctly()
    {
        // Arrange
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Test Category",
            Description = "Test Description",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // Act
        var result = _mapper.Map<CategoryDto>(category);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(category.Id);
        result.Name.Should().Be(category.Name);
        result.Description.Should().Be(category.Description);
        result.CreatedAt.Should().Be(category.CreatedAt);
        result.UpdatedAt.Should().Be(category.UpdatedAt);
    }

    [Fact]
    public void Map_CreateCategoryDto_To_Category_Should_Map_Correctly()
    {
        // Arrange
        var createDto = new CreateCategoryDto(
            "Test Category",
            "Test Description"
        );

        // Act
        var result = _mapper.Map<Category>(createDto);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(createDto.Name);
        result.Description.Should().Be(createDto.Description);
    }

    [Fact]
    public void Map_UpdateCategoryDto_To_Category_Should_Map_Correctly()
    {
        // Arrange
        var updateDto = new UpdateCategoryDto(
            "Updated Category",
            "Updated Description"
        );
        var existingCategory = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Original Name",
            Description = "Original Description",
            CreatedAt = DateTime.UtcNow
        };

        // Act
        var result = _mapper.Map(updateDto, existingCategory);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(updateDto.Name);
        result.Description.Should().Be(updateDto.Description);
        // Original properties should be preserved
        result.Id.Should().Be(existingCategory.Id);
        result.CreatedAt.Should().Be(existingCategory.CreatedAt);
    }
}
