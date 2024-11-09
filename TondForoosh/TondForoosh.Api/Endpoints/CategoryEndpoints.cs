using TondForoosh.Api.Dtos;
using TondForoosh.Api.Endpoints.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace TondForoosh.Api.Endpoints
{
    public static class CategoryEndpoints
    {
        const string CategoryEndpointGroupName = "Categories";

        public static RouteGroupBuilder MapCategoryEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/categories")
                .WithParameterValidation()
                .WithTags(CategoryEndpointGroupName);

            // GET all categories (no authorization required)
            group.MapGet("/", async (CategoryEndpointHandler handler) =>
                await handler.GetAllCategoriesAsync());

            // POST a new category (Admin only)
            group.MapPost("/", [Authorize(Policy = "AdminOnly")] async (CreateCategoryDto dto, CategoryEndpointHandler handler) =>
                await handler.CreateCategoryAsync(dto));

            // PUT an existing category (Admin only)
            group.MapPut("/{id:int}", [Authorize(Policy = "AdminOnly")] async (int id, UpdateCategoryDto dto, CategoryEndpointHandler handler) =>
                await handler.UpdateCategoryAsync(id, dto));

            // DELETE an existing category (Admin only)
            group.MapDelete("/{id:int}", [Authorize(Policy = "AdminOnly")] async (int id, CategoryEndpointHandler handler) =>
                await handler.DeleteCategoryAsync(id));

            return group;
        }
    }
}
