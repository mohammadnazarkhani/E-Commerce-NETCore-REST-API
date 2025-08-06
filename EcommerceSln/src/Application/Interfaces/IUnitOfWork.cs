using Application.Interfaces.Repositories;

namespace Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    ICustomerRepository Customers { get; }
    ICategoryRepository Categories { get; }
    
    Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
}
