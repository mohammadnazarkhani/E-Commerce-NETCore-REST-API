using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TondForoosh.Api.Data.Repositories;
using TondForoosh.Api.Data.Repositories.Interfaces;

namespace TondForoosh.Api.Data
{
    // Unit of Work implementation to manage the transaction across multiple repositories.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TondForooshContext _context;

        // Repositories for different entities
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public ICartItemRepository CartItemRepository { get; }
        public IUserRepository UserRepository { get; }
        public ISellerProductRepository SellerProductRepository { get; }
        public IShoppingCartRepository ShoppingCartRepository { get; }

        public UnitOfWork(TondForooshContext context)
        {
            _context = context;

            // Initialize repositories
            CategoryRepository = new CategoryRepository(context);
            ProductRepository = new ProductRepository(context);
            OrderRepository = new OrderRepository(context);
            CartItemRepository = new CartItemRepository(context);
            UserRepository = new UserRepository(context);
            SellerProductRepository = new SellerProductRepository(context);
            ShoppingCartRepository = new ShoppingCartRepository(context);
        }

        // Save changes to the database within a transaction.
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Dispose of the context when done.
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
