using TondForoosh.Api.Endpoints.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TondForoosh.Api.Data;
using TondForoosh.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace TondForoosh.Api.Endpoints
{
    public static class CategoryEndpoints
    {
        const string GetCategoriesEndpointName = "GetCategories";
        const string GetCategoryEndpointName = "GetCategory";
        const string CreateCategoryEndpointName = "CreateCategory";
        const string UpdateCategoryEndpointName = "UpdateCategory";
        const string DeleteCategoryEndpointName = "DeleteCategory";

        public static void MapCategoryEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("/categories")
                .WithParameterValidation(); // This is for DTO validation if required.

            // GET /categories (For everyone)
            group.MapGet("/", async (CategoryEndpointHandler handler) =>
                await handler.GetAllCategoriesAsync())
                .WithName(GetCategoriesEndpointName);

            // GET /categories/{id} (For everyone)
            group.MapGet("/{id:int}", async (int id, CategoryEndpointHandler handler) =>
                await handler.GetCategoryByIdAsync(id))
                .WithName(GetCategoryEndpointName);

            // POST /categories (Only Admin)
            group.MapPost("/", [Authorize(Policy = "AdminOnly")] async (CreateCategoryDto dto, CategoryEndpointHandler handler) =>
                await handler.CreateCategoryAsync(dto))
                .WithName(CreateCategoryEndpointName);

            // PUT /categories/{id} (Only Admin)
            group.MapPut("/{id:int}", [Authorize(Policy = "AdminOnly")] async (int id, CreateCategoryDto dto, CategoryEndpointHandler handler) =>
                await handler.UpdateCategoryAsync(id, dto))
                .WithName(UpdateCategoryEndpointName);

            // DELETE /categories/{id} (Only Admin)
            group.MapDelete("/{id:int}", [Authorize(Policy = "AdminOnly")] async (int id, CategoryEndpointHandler handler) =>
                await handler.DeleteCategoryAsync(id))
                .WithName(DeleteCategoryEndpointName);
        }
    }
}
