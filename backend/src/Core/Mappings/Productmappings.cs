using System;
using System.Reflection;
using Core.DTOs.Category;
using Core.DTOs.Product;
using Core.Entities;
using Core.Entities.Enums;
using Core.Validation.DTOs.Product;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Core.Mappings;

public static class Productmappings
{
    /// <summary>
    /// Maps a CreateProductDto to a tuple containing the product image file, product image entity, and product entity.
    /// Assumes the DTO has already been validated.
    /// </summary>
    public static (IFormFile Image, ProductImage ProductImage, Product Product) ToNewProductEntities(
        this CreateProductDto createProductDto)
    {
        Product product = new()
        {
            Name = createProductDto.Name.Trim(),
            Description = createProductDto.Description?.Trim(),
            Price = createProductDto.Price,
            CategoryId = createProductDto.CategoryId,
            StockQuantity = createProductDto.StockQuantity,
        };
        product.SetStatus(EntityStatus.Added);

        ProductImage productImage = new()
        {
            Name = string.IsNullOrWhiteSpace(createProductDto.ImageName)
                ? createProductDto.Name.Trim()
                : createProductDto.ImageName.Trim(),
            ContentType = createProductDto.Image.ContentType,
            FileSize = createProductDto.Image.Length,
            Product = product
        };
        productImage.SetStatus(EntityStatus.Added);

        product.MainImage = productImage;

        return (createProductDto.Image, productImage, product);
    }

    public static ProductDetailDto ToProductDetailDto(this Product product)
    {
        var productCategory = product.Category;

        Stack<CategoryDto> categories = new Stack<CategoryDto>();
        var categoryParent = productCategory?.ParentCategory;
        while (categoryParent is not null)
        {
            categories.Push(categoryParent.ToDto());
        }

        var mainImageId = product.MainImage?.Id ?? Guid.Empty;

        return new ProductDetailDto(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.StockQuantity,
            categories,
            mainImageId
        );
    }

    public static ProductListDto ToProductListDto(this Product product)
    {
        return new ProductListDto(
            product.Id,
            product.Name,
            product.Price,
            product.MainImage?.Id ?? Guid.Empty
        );
    }

    public static void UpdateFromDto(this Product product, UpdateProductDto updateProductDto)
    {
        if (product == null || updateProductDto == null) return;

        // Using FluentValidation to validate the DTO
        var validator = new UpdateProductDtoValidator();
        validator.ValidateAndThrow(updateProductDto);

        // Apply updates only for non-null values
        if (updateProductDto.Name != null)
            product.Name = updateProductDto.Name.Trim();

        product.Description = updateProductDto.Description?.Trim();

        if (updateProductDto.Price.HasValue)
            product.Price = updateProductDto.Price.Value;

        if (updateProductDto.CategoryId.HasValue)
            product.CategoryId = updateProductDto.CategoryId.Value;

        if (updateProductDto.StockQuantity.HasValue)
            product.StockQuantity = updateProductDto.StockQuantity.Value;

        product.SetStatus(EntityStatus.Modified);
    }
}
