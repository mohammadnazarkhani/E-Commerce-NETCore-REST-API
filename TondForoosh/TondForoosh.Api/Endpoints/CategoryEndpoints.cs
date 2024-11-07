using TondForoosh.Api.Dtos;
using TondForoosh.Api.Entities;
using TondForoosh.Api.Mapping;
using TondForoosh.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TondForoosh.Api.Endpoints
{
    public static class CategoryEndpoints
    {
        public static RouteGroupBuilder MapCategoryEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/categories")
                .WithParameterValidation();

            // GET /categories (For everyone)
            group.MapGet("/", async (TondForooshContext dbContext) =>
            {
                var categories = await dbContext.ProductCategories
                    .Select(c => c.ToDto()) // Convert to Dto
                    .ToListAsync();

                return Results.Ok(categories);
            })
            .WithName("GetCategories");

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
            .WithName("GetCategory");

            // POST /categories (Only Admin)
            group.MapPost("/", [Authorize(Policy = "AdminOnly")] async (CreateCategoryDto createCategoryDto, TondForooshContext dbContext) =>
            {
                var category = createCategoryDto.ToEntity();

                dbContext.ProductCategories.Add(category);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute("GetCategory", new { id = category.Id }, category.ToDto());
            })
            .WithName("CreateCategory");

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
            .WithName("UpdateCategory");

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
            .WithName("DeleteCategory");

            return group;
        }
    }
}
