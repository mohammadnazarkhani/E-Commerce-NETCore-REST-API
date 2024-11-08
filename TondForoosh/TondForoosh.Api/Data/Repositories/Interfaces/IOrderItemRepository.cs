using TondForoosh.Api.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TondForoosh.Api.Data.Repositories.Interfaces
{
    // The IOrderItemRepository extends the generic IRepository interface for OrderItem.
    // This interface can include additional methods specific to the OrderItem entity.
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        // Retrieves all items of a specific order asynchronously.
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);

        // Adds a new item to the order.
        Task AddOrderItemAsync(OrderItem orderItem);

        // Removes a specific item from the order.
        Task RemoveOrderItemAsync(int orderItemId);
    }
}
