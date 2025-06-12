using ECommerce.RestAPI.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.RestAPI.Entities
{
    public class UserAddress : AuditableEntityBase
    {
        [Length(3, 255)]
        public required string Street { get; set; }
        [Length(0, 255)]
        public string? Alley { get; set; }
        [Length(1, 20)]
        public required string BuildingNumber { get; set; }
        [Length(0, 10)]
        public string? Floor { get; set; }
        [Length(0, 10)]
        public string? UnitNumber { get; set; }
        [RegularExpression(@"^\d{10$|13}$", ErrorMessage = "Invalid Postal Code format. It must be 10 or 13 digits long.")]
        [Length(10, 13)]
        public required string PostalCode { get; set; }
        public required string OwnerName { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone format. It must be exaclty 10 digist long.")]
        [MaxLength(10)]
        public required string PhoneNumber { get; set; }
        [EmailAddress]
        [MaxLength(255)]
        public string? CostumerEmail { get; set;}

        // Relationships
        public required Guid CityId { get; set; }
        public City City { get; set; } = null!;
    }
}
