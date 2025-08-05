using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<Order?> GetByOrderNumberAsync(string orderNumber, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Order>> GetCustomerOrdersAsync(Guid customerId, CancellationToken cancellationToken = default);
}
