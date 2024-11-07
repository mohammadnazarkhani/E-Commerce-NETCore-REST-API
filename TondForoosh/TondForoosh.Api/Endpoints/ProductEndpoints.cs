using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TondForoosh.Api.Dtos;
using TondForoosh.Api.Entities;
using TondForoosh.Api.Services;
using TondForoosh.Api.Data;
using TondForoosh.Api.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace TondForoosh.Api.Endpoints
{
    public static class ProductEndpoints
    {
        const string ProductEndpointGroupName = "Products";

        public static RouteGroupBuilder MapProductEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(ProductEndpointGroupName)
                .WithParameterValidation();

            // GET /products (for getting a list of all products)
            group.MapGet("/", async (TondForooshContext dbContext) =>
            {
                var products = await dbContext.Products
                    .Include(p => p.ProductCategory) // Ensure ProductCategory is loaded
                    .Include(p => p.Seller)          // Ensure Seller is loaded
                    .ToListAsync();

                return products.Select(p => p.ToDto());
            }).AllowAnonymous()  // Allow everyone to view the list
              .WithName("GetAllProducts");

            // GET /products/{id} (for getting a specific product by Id)
            group.MapGet("/{id}", async (int id, [FromServices] TondForooshContext dbContext) =>
            {
                var product = await dbContext.Products
                    .Include(p => p.ProductCategory)
                    .Include(p => p.Seller)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (product == null)
                    return Results.NotFound();

                return Results.Ok(product.ToDetailDto());
            }).AllowAnonymous()  // Allow everyone to view product details
              .WithName("GetProductById");


            // POST /products (for adding a new product) - Only for sellers
            group.MapPost("/", async (CreateProductDto createProductDto, TondForooshContext dbContext, IAuthService authService) =>
            {
                // Check if the user is a seller
                var user = authService.GetCurrentUser(); // You need to implement GetCurrentUser in AuthService
                if (user == null || user.Role != UserRole.Seller)
                {
                    return Results.Forbid();  // Return 403 Forbidden if not a seller
                }

                var product = createProductDto.ToEntity();
                product.UserId = user.Id;  // Assign the seller's ID to the product

                dbContext.Products.Add(product);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute("GetProductById", new { id = product.Id }, product.ToDto());
            }).RequireAuthorization("SellerOnly")  // Only sellers can add a product
              .WithName("CreateProduct");

            // PUT /products/{id} (for updating an existing product) - Only for sellers
            group.MapPut("/{id}", async (int id, UpdateProductDto updateProductDto, TondForooshContext dbContext, IAuthService authService) =>
            {
                var user = authService.GetCurrentUser(); // You need to implement GetCurrentUser in AuthService
                if (user == null || user.Role != UserRole.Seller)
                {
                    return Results.Forbid();  // Return 403 Forbidden if not a seller
                }

                var product = await dbContext.Products
                    .FirstOrDefaultAsync(p => p.Id == id && p.UserId == user.Id);  // Ensure the seller owns the product

                if (product == null)
                {
                    return Results.NotFound(); // Product not found or seller doesn't own the product
                }

                product.UpdateEntity(updateProductDto);
                await dbContext.SaveChangesAsync();

                return Results.Ok(product.ToDto());
            }).RequireAuthorization("SellerOnly")  // Only sellers can update their products
              .WithName("UpdateProduct");

            // DELETE /products/{id} (for deleting a product) - Only for sellers
            group.MapDelete("/{id}", async (int id, TondForooshContext dbContext, IAuthService authService) =>
            {
                var user = authService.GetCurrentUser(); // You need to implement GetCurrentUser in AuthService
                if (user == null || user.Role != UserRole.Seller)
                {
                    return Results.Forbid();  // Return 403 Forbidden if not a seller
                }

                var product = await dbContext.Products
                    .FirstOrDefaultAsync(p => p.Id == id && p.UserId == user.Id);  // Ensure the seller owns the product

                if (product == null)
                {
                    return Results.NotFound(); // Product not found or seller doesn't own the product
                }

                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            }).RequireAuthorization("SellerOnly")  // Only sellers can delete their products
              .WithName("DeleteProduct");

            return group;
        }
    }
}
