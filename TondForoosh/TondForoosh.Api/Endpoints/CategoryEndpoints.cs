using TondForoosh.Api.Dtos;
using TondForoosh.Api.Entities;
using TondForoosh.Api.Mapping;
using TondForoosh.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TondForoosh.Api.Endpoints
{
    public static class CategoryEndpoints
    {
        const string GetCategoriesEndpointName = "GetCategories";
        const string GetCategoryEndpointName = "GetCategory";
        const string CreateCategoryEndpointName = "CreateCategory";
        const string UpdateCategoryEndpointName = "UpdateCategory";
        const string DeleteCategoryEndpointName = "DeleteCategory";

        public static RouteGroupBuilder MapCategoryEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/categories")
                .WithParameterValidation(); // This is for DTO validation if required.

            // GET /categories (For everyone)
            group.MapGet("/", async (TondForooshContext dbContext) =>
            {
                var categories = await dbContext.ProductCategories
                    .Select(c => c.ToDto()) // Convert to Dto
                    .ToListAsync();

                return Results.Ok(categories);
            })
            .WithName(GetCategoriesEndpointName); // Name for this endpoint

            // GET /categories/{id} (For everyone)
            group.MapGet("/{id}", async (int id, TondForooshContext dbContext) =>
            {
                var category = await dbContext.ProductCategories
                    .Where(c => c.Id == id)
                    .Select(c => c.ToDto()) // Convert to Dto
                    .FirstOrDefaultAsync();

                if (category == null)
                    return Results.NotFound();

                return Results.Ok(category);
            })
            .WithName(GetCategoryEndpointName); // Name for this endpoint

            // POST /categories (Only Admin)
            group.MapPost("/", [Authorize(Policy = "AdminOnly")] async (CreateCategoryDto createCategoryDto, TondForooshContext dbContext) =>
            {
                var category = createCategoryDto.ToEntity();

                dbContext.ProductCategories.Add(category);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(GetCategoryEndpointName, new { id = category.Id }, category.ToDto());
            })
            .WithName(CreateCategoryEndpointName); // Name for this endpoint

            // PUT /categories/{id} (Only Admin)
            group.MapPut("/{id}", [Authorize(Policy = "AdminOnly")] async (int id, CreateCategoryDto createCategoryDto, TondForooshContext dbContext) =>
            {
                var category = await dbContext.ProductCategories.FindAsync(id);
                if (category == null)
                    return Results.NotFound();

                category.Title = createCategoryDto.Title; // Assuming the name is being updated
                dbContext.ProductCategories.Update(category);
                await dbContext.SaveChangesAsync();

                return Results.Ok(category.ToDto());
            })
            .WithName(UpdateCategoryEndpointName); // Name for this endpoint

            // DELETE /categories/{id} (Only Admin)
            group.MapDelete("/{id}", [Authorize(Policy = "AdminOnly")] async (int id, TondForooshContext dbContext) =>
            {
                var category = await dbContext.ProductCategories.FindAsync(id);
                if (category == null)
                    return Results.NotFound();

                dbContext.ProductCategories.Remove(category);
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            })
            .WithName(DeleteCategoryEndpointName); // Name for this endpoint

            return group;
        }
    }
}
