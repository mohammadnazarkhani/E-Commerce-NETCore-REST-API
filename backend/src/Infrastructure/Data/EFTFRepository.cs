using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class EFTFRepository : ITondForooshRepository
{
    private TFDbContext context;

    public EFTFRepository(TFDbContext ctx)
    {
        context = ctx;
    }

    public IQueryable<Product> Products => context.Products;

    public async Task<long> AddAsync(Product product)
    {
        await context.AddAsync(product);
        await context.SaveChangesAsync();
        return product.Id;
    }

    public async Task UpdateAsync(Product product)
    {
        var entry = context.Entry(product);
        if (entry.State == EntityState.Detached)
            context.Products.Attach(product);

        entry.State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }

    public IQueryable<Category> Categories => context.Categories;

    public async Task<int> AddCategoryAsync(Category category)
    {
        await context.AddAsync(category);
        await context.SaveChangesAsync();
        return category.Id;
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        var entry = context.Entry(category);
        if (entry.State == EntityState.Detached)
            context.Categories.Attach(category);

        entry.State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(Category category)
    {
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
    }
}
