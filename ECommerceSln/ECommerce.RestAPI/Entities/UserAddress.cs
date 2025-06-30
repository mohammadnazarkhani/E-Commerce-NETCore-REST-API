using ECommerce.RestAPI.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.RestAPI.Entities
{
    /// <summary>
    /// Represents a physical address associated with a user in the e-commerce system.
    /// This entity stores detailed address information including contact details.
    /// </summary>
    /// <remarks>
    /// Inherits from <see cref="AuditableEntityBase"/> to track creation and modification dates.
    /// All required fields must be provided when creating a new address.
    /// </remarks>
    public class UserAddress : AuditableEntityBase
    {
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public required string Street { get; set; }
        [StringLength(255)]
        public string? Alley { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public required string BuildingNumber { get; set; }
        [MaxLength(10)]
        public string? Floor { get; set; }
        [MaxLength(10)]
        public string? UnitNumber { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$|^\d{13}$", ErrorMessage = "Invalid Postal Code format. It must be 10 or 13 digits long.")]
        [StringLength(13, MinimumLength = 10)]
        public required string PostalCode { get; set; }
        [Required]
        public required string OwnerName { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone format. It must be exaclty 10 digist long.")]
        [MaxLength(10)]
        public required string PhoneNumber { get; set; }
        [EmailAddress]
        [MaxLength(255)]
        public string? CostumerEmail { get; set;}

        // Relationships
        public required Guid CityId { get; set; }
        public City City { get; set; } = null!;

        public required Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
