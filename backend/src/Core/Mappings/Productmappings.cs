using System;
using Core.DTOs.Category;
using Core.DTOs.Product;
using Core.Entities;
using Core.Entities.Enums;
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
        Queue<CategoryDto> categories = new Queue<CategoryDto>();
        var categoryParent = productCategory.ParentCategory;
        while (categoryParent is not null)
        {
            
        }
            return new ProductDetailDto(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.StockQuantity,
                product.
    
            );
    }
}
