using TondForoosh.Api.Dtos;
using TondForoosh.Api.Services;
using TondForoosh.Api.Data;
using Microsoft.EntityFrameworkCore;
using TondForoosh.Api.Entities;
using TondForoosh.Api.Mapping;

namespace TondForoosh.Api.Endpoints
{
    public static class ProductEndpoints
    {
        const string GetProductByIdEndpointName = "GetProductById";
        const string GetAllProductsEndpointName = "GetAllProducts";
        const string GetSellerProductsEndpointName = "GetSellerProducts";
        const string CreateProductEndpointName = "CreateProduct";
        const string UpdateProductEndpointName = "UpdateProduct";
        const string DeleteProductEndpointName = "DeleteProduct";
        const string ProductEndpointGroupName = "Product";

        public static RouteGroupBuilder MapProductEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(ProductEndpointGroupName)
                .WithParameterValidation(); // Optional: Add validation as needed

            // GET /products (Get all products, open for everyone)
            group.MapGet("/products", async (TondForooshContext dbContext) =>
            {
                var products = await dbContext.Products
                    .Include(p => p.ProductCategory)
                    .Include(p => p.SellerProducts)
                    .ThenInclude(sp => sp.Seller)
                    .ToListAsync();

                return Results.Ok(products.Select(p => p.ToDto()));  // Return products DTO
            }).AllowAnonymous()  // Open for everyone
              .WithName(GetAllProductsEndpointName);

            // GET /products/{id} (Get specific product by Id, open for everyone)
            group.MapGet("/products/{id}", async (int id, TondForooshContext dbContext) =>
            {
                var product = await dbContext.Products
                    .Include(p => p.ProductCategory)
                    .Include(p => p.SellerProducts)
                    .ThenInclude(sp => sp.Seller)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (product == null)
                    return Results.NotFound();

                return Results.Ok(product.ToDetailDto());  // Return detailed product DTO
            }).AllowAnonymous()  // Open for everyone
              .WithName(GetProductByIdEndpointName);

            // GET /products/seller (Get all products for the authenticated seller)
            group.MapGet("/products/seller", async (TondForooshContext dbContext, IAuthService authService) =>
            {
                var currentUser = authService.GetCurrentUser();  // Get the current authenticated user
                if (currentUser == null || currentUser.Role != UserRole.Seller)
                    return Results.Unauthorized();  // Unauthorized if not seller

                var sellerProducts = await dbContext.SellerProducts
                    .Where(sp => sp.UserId == currentUser.Id)
                    .Include(sp => sp.Product)
                    .ThenInclude(p => p.ProductCategory)
                    .Select(sp => sp.Product.ToDto())
                    .ToListAsync();

                return Results.Ok(sellerProducts);  // Return seller's products DTO
            }).RequireAuthorization()  // Requires authentication and seller role
              .WithName(GetSellerProductsEndpointName);

            // POST /products (Create a new product, only accessible by seller)
            group.MapPost("/products", async (CreateProductDto createProductDto, TondForooshContext dbContext, IAuthService authService) =>
            {
                var currentUser = authService.GetCurrentUser();  // Get the current authenticated user
                if (currentUser == null || currentUser.Role != UserRole.Seller)
                    return Results.Unauthorized();  // Unauthorized if not seller

                var product = createProductDto.ToEntity();
                product.SellerProducts.Add(new SellerProduct
                {
                    UserId = currentUser.Id,  // Link the seller to the product
                    Product = product
                });

                dbContext.Products.Add(product);
                await dbContext.SaveChangesAsync();

                return Results.Created($"/products/{product.Id}", product.ToDetailDto());  // Return created product DTO
            }).RequireAuthorization()  // Requires authentication and seller role
              .WithName(CreateProductEndpointName);

            // PUT /products/{id} (Update product by Id, only accessible by seller)
            group.MapPut("/products/{id}", async (int id, UpdateProductDto updateProductDto, TondForooshContext dbContext, IAuthService authService) =>
            {
                var currentUser = authService.GetCurrentUser();  // Get the current authenticated user
                if (currentUser == null || currentUser.Role != UserRole.Seller)
                    return Results.Unauthorized();  // Unauthorized if not seller

                var product = await dbContext.Products
                    .Include(p => p.SellerProducts)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (product == null)
                    return Results.NotFound();

                // Check if the current user is the seller of the product
                var sellerProduct = product.SellerProducts.FirstOrDefault(sp => sp.UserId == currentUser.Id);
                if (sellerProduct == null)
                    return Results.StatusCode(403);  // Forbidden if the product is not owned by the seller

                product.UpdateEntity(updateProductDto);  // Update product data
                await dbContext.SaveChangesAsync();

                return Results.Ok(product.ToDetailDto());  // Return updated product DTO
            }).RequireAuthorization()  // Requires authentication and seller role
              .WithName(UpdateProductEndpointName);

            // DELETE /products/{id} (Delete product by Id, only accessible by seller)
            group.MapDelete("/products/{id}", async (int id, TondForooshContext dbContext, IAuthService authService) =>
            {
                var currentUser = authService.GetCurrentUser();  // Get the current authenticated user
                if (currentUser == null || currentUser.Role != UserRole.Seller)
                    return Results.Unauthorized();  // Unauthorized if not seller

                var product = await dbContext.Products
                    .Include(p => p.SellerProducts)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (product == null)
                    return Results.NotFound();

                // Check if the current user is the seller of the product
                var sellerProduct = product.SellerProducts.FirstOrDefault(sp => sp.UserId == currentUser.Id);
                if (sellerProduct == null)
                    return Results.StatusCode(403);  // Forbidden if the product is not owned by the seller

                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();

                return Results.NoContent();  // Return no content response after successful deletion
            }).RequireAuthorization()  // Requires authentication and seller role
              .WithName(DeleteProductEndpointName);

            return group;
        }
    }
}
