using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> IsNameUniqueAsync(string name, CancellationToken cancellationToken = default);
}
