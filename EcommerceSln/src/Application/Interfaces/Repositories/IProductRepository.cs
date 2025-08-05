using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product?> GetBySkuAsync(string sku, CancellationToken cancellationToken = default);
    Task<bool> IsSkuUniqueAsync(string sku, CancellationToken cancellationToken = default);
}
