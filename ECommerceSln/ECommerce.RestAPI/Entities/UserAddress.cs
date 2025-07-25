﻿using ECommerce.RestAPI.Entities.Base;
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
        public string Street { get; set; } = string.Empty;
        [StringLength(255)]
        public string? Alley { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string BuildingNumber { get; set; } = string.Empty;
        [MaxLength(10)]
        public string? Floor { get; set; }
        [MaxLength(10)]
        public string? UnitNumber { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$|^\d{13}$", ErrorMessage = "Invalid Postal Code format. It must be 10 or 13 digits long.")]
        [StringLength(13, MinimumLength = 10)]
        public string PostalCode { get; set; } = string.Empty;
        [Required]
        public string OwnerName { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone format. It must be exaclty 10 digist long.")]
        [MaxLength(10)]
        public string PhoneNumber { get; set; } = string.Empty;
        [EmailAddress]
        [MaxLength(255)]
        public string? CostumerEmail { get; set; }

        // Relationships
        [Required]
        public Guid CityId { get; set; }
        public City City { get; set; } = null!;

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
