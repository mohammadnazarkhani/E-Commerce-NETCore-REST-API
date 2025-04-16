using Core.Entities;

namespace Infrastructure.Data;

public interface ITondForooshRepository
{
    IQueryable<Product> Products { get; }
    Task<long> AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);

    IQueryable<Category> Categories { get; }
    Task<int> AddCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(Category category);
}
