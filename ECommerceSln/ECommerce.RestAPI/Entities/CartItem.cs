using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities
{
    public class CartItem : AuditableEntityBase
    {
        [Required]
        public int Quantity { get; set; }

        // Relationships
        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Required]
        public Guid CartId { get; set; }
        public Cart Cart { get; set; } = null!;
    }
}
