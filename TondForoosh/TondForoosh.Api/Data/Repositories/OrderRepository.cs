using TondForoosh.Api.Data.Repositories.Interfaces;
using TondForoosh.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TondForoosh.Api.Data.Repositories
{
    // OrderRepository extends the generic Repository to provide CRUD operations for Order.
    // It implements IOrderRepository to handle order specific queries like getting orders by user and updating order status.
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        // Constructor that passes the DbContext instance to the base Repository class.
        public OrderRepository(TondForooshContext context) : base(context) { }

        // Retrieves all orders for a specific user asynchronously.
        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)  // Filter by user ID.
                .Include(o => o.OrderItems)  // Include order items for each order.
                .ToListAsync();  // Executes the query asynchronously and returns the list.
        }

        // Updates the status of an existing order.
        public async Task UpdateOrderStatusAsync(int orderId, string newStatus)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == orderId);  // Find the order by ID.

            if (order != null)
            {
                order.OrderStatus = newStatus;  // Update the status.
                _context.Orders.Update(order);  // Mark the order as modified.
                await _context.SaveChangesAsync();  // Save the changes to the database.
            }
        }

        // Retrieves an order by its ID, including its order items.
        public async Task<Order> GetOrderByIdWithItemsAsync(int orderId)
        {
            return await _context.Orders
                .Where(o => o.Id == orderId)  // Filter by order ID.
                .Include(o => o.OrderItems)  // Include order items.
                .ThenInclude(oi => oi.Product)  // Optionally, include product information for each order item.
                .FirstOrDefaultAsync();  // Return the first match or null if not found.
        }
    }
}
