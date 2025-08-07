using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Interfaces;

public interface IUnitOfWork : IAsyncDisposable
{
    // Repositories
    IGenericRepository<Product> Products { get; }
    IGenericRepository<Category> Categories { get; }
    IGenericRepository<Order> Orders { get; }
    IGenericRepository<OrderItem> OrderItems { get; }
    IGenericRepository<Customer> Customers { get; }
    IGenericRepository<Address> Addresses { get; }

    // Transaction management
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();

    // Save changes
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
