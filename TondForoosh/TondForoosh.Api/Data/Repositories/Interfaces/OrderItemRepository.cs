using TondForoosh.Api.Data.Repositories.Interfaces;
using TondForoosh.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TondForoosh.Api.Data.Repositories
{
    // OrderItemRepository extends the generic Repository to provide CRUD operations for OrderItem.
    // It implements IOrderItemRepository to handle order item specific queries like adding/removing items and retrieving order items.
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        // Constructor that passes the DbContext instance to the base Repository class.
        public OrderItemRepository(TondForooshContext context) : base(context) { }

        // Retrieves all items of a specific order asynchronously.
        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await _context.OrderItems
                .Where(oi => oi.OrderId == orderId)  // Filter by order ID.
                .Include(oi => oi.Product)  // Include product information for each order item.
                .ToListAsync();  // Executes the query asynchronously and returns the list.
        }

        // Adds a new item to the order.
        public async Task AddOrderItemAsync(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);  // Adds the new order item to the DbSet.
        }

        // Removes a specific item from the order by order item ID.
        public async Task RemoveOrderItemAsync(int orderItemId)
        {
            var orderItem = await _context.OrderItems
                .FirstOrDefaultAsync(oi => oi.Id == orderItemId);  // Finds the order item by ID.

            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);  // Remove the order item from the DbSet.
            }
        }
    }
}
