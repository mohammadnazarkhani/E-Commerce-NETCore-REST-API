using ECommerce.RestAPI.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.RestAPI.Entities
{
    public class Vendor : AuditableEntityBase
    {
        [Required]
        [StringLength(100, ErrorMessage = "Vendor Name cannot be longer than 100 characters.")]
        public required string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Enter a valid email address. Example: example@domain.com")]
        public required string Email { get; set; }

        [StringLength(255)]
        public string Address { get; set; } = null!;

        // Relationships
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
