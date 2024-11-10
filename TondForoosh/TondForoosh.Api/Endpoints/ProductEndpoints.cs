using TondForoosh.Api.Endpoints.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using TondForoosh.Api.Dtos.Product;

namespace TondForoosh.Api.Endpoints
{
    public static class ProductEndpoints
    {
        const string ProductEndpointGroupName = "Products";

        public static RouteGroupBuilder MapProductEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/products")
                .WithParameterValidation()
                .WithTags(ProductEndpointGroupName);

            group.MapGet("/", async (ProductEndpointHandler handler) =>
                await handler.GetAllProductsAsync());

            group.MapGet("/{id:int}", async (int id, ProductEndpointHandler handler) =>
                await handler.GetProductByIdAsync(id));

            group.MapPost("/", [Authorize(Policy = "SellerOnly")] async (CreateProductDto dto, ProductEndpointHandler handler) =>
                await handler.CreateProductAsync(dto));

            group.MapPut("/{id:int}", [Authorize(Policy = "SellerOnly")] async (int id, UpdateProductDto dto, ProductEndpointHandler handler) =>
                await handler.UpdateProductAsync(id, dto));

            group.MapDelete("/{id:int}", [Authorize(Policy = "SellerOnly")] async (int id, ProductEndpointHandler handler) =>
                await handler.DeleteProductAsync(id));

            return group;
        }
    }
}
