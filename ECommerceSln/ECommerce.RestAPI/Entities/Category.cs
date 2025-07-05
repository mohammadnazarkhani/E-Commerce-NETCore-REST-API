using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities
{
    public class Category : AuditableEntityBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Relationships
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
