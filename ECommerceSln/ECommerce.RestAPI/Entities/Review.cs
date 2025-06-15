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
        public required string Comment { get; set; }

        /// <summary>
        /// Gets or sets the rating score for this review.
        /// </summary>
        /// <remarks>
        /// The rating is stored as an enum value from 1 to 5 stars.
        /// </remarks>
        [EnumDataType(typeof(Rating))]
        public Rating RatingScore { get; set; }
    }
}
