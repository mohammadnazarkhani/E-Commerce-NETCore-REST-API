using ECommerce.RestAPI.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.RestAPI.Entities
{
    public class UserAddress : AuditableEntityBase
    {
        public required string Street { get; set; }
        public string? Alley { get; set; }
        public required string BuildingNumber { get; set; }
        public string? Floor { get; set; }
        public string? UnitNumber { get; set; }
        [MaxLength(10)]
        public required string PostalCode { get; set; }
        public required string OwnerName { get; set; }
        [MaxLength(10)]
        public required string PhoneNumber { get; set; }
        [EmailAddress]
        public string? CostumerEmail {get; set;}

        // Relationships
        public Guid CityId { get; set; }
        public City? City { get; set; }
    }
}
