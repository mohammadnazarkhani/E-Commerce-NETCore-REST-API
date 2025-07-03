using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities
{
    public class Question : AuditableEntityBase
    {
        [Required]
        [MaxLength(500)]
        public required string Quest { get; set; }

        public string? Answer { get; set; }

        // Relationships
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
