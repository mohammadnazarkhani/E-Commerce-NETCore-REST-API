using System;
using System.Threading.Tasks;
using TondForoosh.Api.Data.Repositories.Interfaces;

namespace TondForoosh.Api.Data
{
    // Unit of Work interface to handle multiple repositories in a single transaction.
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        ICartItemRepository CartItemRepository { get; }
        IUserRepository UserRepository { get; }
        ISellerProductRepository SellerProductRepository { get; }
        IShoppingCartRepository ShoppingCartRepository { get; }

        // Commit all changes to the database.
        Task<int> SaveChangesAsync();
    }
}
