using TondForoosh.Api.Dtos;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Mapping
{
    public static class ProductMapping
    {
        // Convert CreateProductDto to Product entity
        public static Product ToEntity(this CreateProductDto createProductDto)
        {
            return new Product
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                ProductCategoryId = createProductDto.ProductCategoryId
            };
        }

        // Convert UpdateProductDto to Product entity (updating the product)
        public static Product UpdateEntity(this Product product, UpdateProductDto updateProductDto)
        {
            product.Name = updateProductDto.Name;
            product.Price = updateProductDto.Price;
            product.ProductCategoryId = updateProductDto.ProductCategoryId;

            return product;
        }

        // Convert Product entity to ProductDto (for listing products)
        public static ProductDto ToDto(this Product product)
        {
            // Extract seller username from SellerProduct relationship
            var sellerProduct = product.SellerProducts.FirstOrDefault();
            var sellerUsername = sellerProduct?.Seller?.Username ?? "Unknown";  // Default value in case no seller is found

            return new ProductDto(
                product.Id,
                product.Name,
                product.Price,
                product.ProductCategory.Title,  // Assuming that ProductCategory is included in the product entity
                sellerUsername  // Seller's username fetched from SellerProduct
            );
        }

        // Convert Product entity to ProductDetailDto (for detailed view)
        public static ProductDetailDto ToDetailDto(this Product product)
        {
            // Extract seller username from SellerProduct relationship
            var sellerProduct = product.SellerProducts.FirstOrDefault();
            var sellerUsername = sellerProduct?.Seller?.Username ?? "Unknown";  // Default value in case no seller is found

            return new ProductDetailDto(
                product.Id,
                product.Name,
                product.Price,
                product.ProductCategory.Title,  // Category Title
                sellerUsername        // Seller Username fetched from SellerProduct
            );
        }
    }
}
