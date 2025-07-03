using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities
{
    public class Category : AuditableEntityBase
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        // Relationships
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
