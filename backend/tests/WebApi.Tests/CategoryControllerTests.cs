using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using Core.Entities;
using MockQueryable;
using Core.DTOs.Categories.Requests;
using Core.DTOs.Categories.Responses;
using AutoMapper;
using Infrastructure.Data;
using Core.Mapping;

namespace TondForooshApi.Tests;

public class CategoryControllerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ITondForooshRepository> _mockRepo;
    private readonly CategoryController _controller;
    private readonly List<Category> _testCategories;

    public CategoryControllerTests()
    {
        // Setup mapper
        var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
        _mapper = mappingConfig.CreateMapper();

        // Setup test data
        _testCategories = new List<Category>
        {
            new Category { Id = 1, Name = "Category1" },
            new Category { Id = 2, Name = "Category2" }
        };

        // Setup repository and controller
        _mockRepo = new Mock<ITondForooshRepository>();
        _mockRepo.Setup(m => m.Categories).Returns(_testCategories.AsQueryable().BuildMock());
        _controller = new CategoryController(_mockRepo.Object, _mapper);
    }

    #region Get Operations
    [Fact]
    public async Task GetCategories_ShouldReturnAllCategories_WhenCategoriesExist()
    {
        // Act
        var result = await _controller.GetCategories();
        
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedCategories = Assert.IsAssignableFrom<IEnumerable<CategoryDto>>(okResult.Value);
        Assert.Equal(2, returnedCategories.Count());
    }

    [Fact]
    public async Task GetCategory_ShouldReturnCategory_WhenIdExists()
    {
        // Act
        var result = await _controller.GetCategory(1);
        
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedCategory = Assert.IsType<CategoryDto>(okResult.Value);
        Assert.Equal("Category1", returnedCategory.Name);
    }

    [Fact]
    public async Task GetCategory_ShouldReturnNotFound_WhenIdDoesNotExist()
    {
        // Arrange
        _mockRepo.Setup(m => m.Categories).Returns(new List<Category>().AsQueryable().BuildMock());
        
        // Act
        var result = await _controller.GetCategory(1);
        
        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
    #endregion

    #region Create Operations
    [Fact]
    public async Task CreateCategory_ShouldCreateNewCategory_WhenValidDataProvided()
    {
        // Arrange
        _mockRepo.Setup(m => m.AddCategoryAsync(It.IsAny<Category>())).ReturnsAsync(1);
        var createDto = new CreateCategoryDto("Test Category");

        // Act
        var result = await _controller.CreateCategory(createDto);
        
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var categoryId = Assert.IsType<int>(okResult.Value);
        Assert.Equal(1, categoryId);
    }
    #endregion

    #region Update Operations
    [Fact]
    public async Task UpdateCategory_ShouldUpdateSuccessfully_WhenValidDataProvided()
    {
        // Arrange
        var categoryToUpdate = _testCategories.First();
        var updateDto = new UpdateCategoryDto(1, "Updated Name");
        Category? capturedCategory = null;
        _mockRepo.Setup(m => m.UpdateCategoryAsync(It.IsAny<Category>()))
            .Callback<Category>(c => capturedCategory = c)
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.UpdateCategory(1, updateDto);

        // Assert
        Assert.IsType<NoContentResult>(result);
        Assert.NotNull(capturedCategory);
        Assert.Equal("Updated Name", capturedCategory!.Name);
        Assert.Equal(1, capturedCategory.Id);
    }

    [Fact]
    public async Task UpdateCategory_ShouldReturnBadRequest_WhenIdsMismatch()
    {
        // Arrange
        var updateDto = new UpdateCategoryDto(2, "New Name");

        // Act
        var result = await _controller.UpdateCategory(1, updateDto);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("ID mismatch", badRequestResult.Value);
    }

    [Fact]
    public async Task UpdateCategory_ShouldReturnBadRequest_WhenModelStateInvalid()
    {
        // Arrange
        _controller.ModelState.AddModelError("Name", "Name is required");
        var updateDto = new UpdateCategoryDto(1, "New Name");

        // Act
        var result = await _controller.UpdateCategory(1, updateDto);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UpdateCategory_ShouldReturnNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        _mockRepo.Setup(m => m.Categories).Returns(new List<Category>().AsQueryable().BuildMock());
        var updateDto = new UpdateCategoryDto(999, "New Name");

        // Act
        var result = await _controller.UpdateCategory(999, updateDto);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    // Keep existing theory test
    [Theory]
    [InlineData(null, typeof(BadRequestObjectResult))]
    [InlineData("", typeof(NoContentResult))]
    [InlineData("New Name", typeof(NoContentResult))]
    public async Task UpdateCategory_ShouldReturnExpectedResult_ForDifferentInputs(string? newName, Type expectedResultType)
    {
        // Arrange
        var updateDto = newName != null ? new UpdateCategoryDto(1, newName) : null!;

        // Act
        var result = await _controller.UpdateCategory(1, updateDto);

        // Assert
        Assert.IsType(expectedResultType, result);
    }
    #endregion

    #region Delete Operations
    [Theory]
    [InlineData(1, typeof(NoContentResult))]
    [InlineData(999, typeof(NotFoundResult))]
    public async Task DeleteCategory_ShouldReturnExpectedResult_ForDifferentIds(int id, Type expectedResultType)
    {
        // Act
        var result = await _controller.DeleteCategory(id);

        // Assert
        Assert.IsType(expectedResultType, result);
    }
    #endregion
}
