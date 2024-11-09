using TondForoosh.Api.Endpoints.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TondForoosh.Api.Data;
using TondForoosh.Api.Dtos;
using System.Threading.Tasks;

namespace TondForoosh.Api.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("/products");

            group.MapGet("/", async (ProductEndpointHandler handler) =>
                await handler.GetAllProductsAsync());

            group.MapGet("/{id:int}", async (int id, ProductEndpointHandler handler) =>
                await handler.GetProductByIdAsync(id));

            group.MapPost("/", async (CreateProductDto dto, ProductEndpointHandler handler, IHttpContextAccessor context) =>
            {
                var sellerId = int.Parse(context.HttpContext.User.Identity.Name); // Get seller ID from context
                return await handler.CreateProductAsync(dto, sellerId);
            }).RequireAuthorization();

            group.MapPut("/{id:int}", async (int id, UpdateProductDto dto, ProductEndpointHandler handler, IHttpContextAccessor context) =>
            {
                var sellerId = int.Parse(context.HttpContext.User.Identity.Name); // Get seller ID from context
                return await handler.UpdateProductAsync(id, dto, sellerId);
            }).RequireAuthorization();

            group.MapDelete("/{id:int}", async (int id, ProductEndpointHandler handler, IHttpContextAccessor context) =>
            {
                var sellerId = int.Parse(context.HttpContext.User.Identity.Name); // Get seller ID from context
                return await handler.DeleteProductAsync(id, sellerId);
            }).RequireAuthorization();
        }
    }
}
