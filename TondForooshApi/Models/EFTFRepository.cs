using System;

namespace TondForooshApi.Models;

public class EFTFRepository : ITondForooshRepository
{
    private TFDbContext context;

    public EFTFRepository(TFDbContext ctx)
    {
        context = ctx;
    }

    public IQueryable<Product> Products => context.Products;
}
