using ECommerce.RestAPI.Entities.Base;
using ECommerce.RestAPI.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.RestAPI.Entities
{
    /// <summary>
    /// Represents a review entry in the system.
    /// </summary>
    public class Review : AuditableEntityBase
    {
        /// <summary>
        /// Gets or sets the review comment text.
        /// </summary>
        [Required]
        [StringLength(1000, ErrorMessage = "Review comment should not exeed 1000 characters.")]
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the rating score for this review.
        /// </summary>
        /// <remarks>
        /// The rating is stored as an enum value from 1 to 5 stars.
        /// </remarks>
        [Required]
        [EnumDataType(typeof(Rating))]
        public Rating RatingScore { get; set; }

        // Relationships
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
