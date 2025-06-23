using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities
{
    public class Question : AuditableEntityBase
    {
        public required string Quest { get; set; }
        public string? Answer { get; set; }

        // Relationships
        public required Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public required Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
