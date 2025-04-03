using System;
using Core.DTOs.Product;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Core.Mappings;

public static class Productmappings
{
    public static (IFormFile, ProductImage, Product) ToEntities(this CreateProductDto createProductDto)
    {
        Product product = new Product
        {
            Name = createProductDto.Name,
            Description = createProductDto.Description,
            Price = createProductDto.Price,
            CategoryId = createProductDto.CategoryId,
            StockQuantity = createProductDto.StockQuantity
        };

        ProductImage productImage = new()
        {
            Name = createProductDto.ImageName.Trim(),
            ContentType = createProductDto.Image.ContentType,
            FileSize = createProductDto.Image.Length,
            Product = product
        };

        product.MainImage = productImage;

        return (createProductDto.Image, productImage, product);
    }
}
