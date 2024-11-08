using TondForoosh.Api.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TondForoosh.Api.Data.Repositories.Interfaces
{
    // The IOrderRepository extends the generic IRepository interface for Order.
    // This interface can include additional methods specific to the Order entity.
    public interface IOrderRepository : IRepository<Order>
    {
        // Retrieves all orders for a specific user asynchronously.
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);

        // Updates the status of an existing order.
        Task UpdateOrderStatusAsync(int orderId, string newStatus);

        // Retrieves an order by its ID, including its order items.
        Task<Order> GetOrderByIdWithItemsAsync(int orderId);
    }
}
