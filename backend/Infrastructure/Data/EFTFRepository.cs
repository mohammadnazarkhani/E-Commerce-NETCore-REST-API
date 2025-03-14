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
}
