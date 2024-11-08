using TondForoosh.Api.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TondForoosh.Api.Data.Repositories.Interfaces
{
    // The ISellerProductRepository extends the generic IRepository interface for SellerProduct.
    // This interface can include additional methods specific to the SellerProduct entity.
    public interface ISellerProductRepository : IRepository<SellerProduct>
    {
        // Retrieves all products for a specific seller asynchronously.
        Task<IEnumerable<SellerProduct>> GetProductsBySellerIdAsync(int sellerId);

        // Checks if a specific product is associated with a seller.
        Task<bool> IsProductAssociatedWithSellerAsync(int sellerId, int productId);
    }
}
