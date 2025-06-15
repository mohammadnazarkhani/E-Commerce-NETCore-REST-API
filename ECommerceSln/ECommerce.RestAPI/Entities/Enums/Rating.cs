namespace ECommerce.RestAPI.Entities.Enums
{
    /// <summary>
    /// Represents the rating score that can be assigned in a review.
    /// </summary>
    public enum Rating : byte
    {
        /// <summary>
        /// Very poor rating (1 star)
        /// </summary>
        VeryPoor = 1,

        /// <summary>
        /// Poor rating (2 stars)
        /// </summary>
        Poor = 2,

        /// <summary>
        /// Average rating (3 stars)
        /// </summary>
        Average = 3,

        /// <summary>
        /// Good rating (4 stars)
        /// </summary>
        Good = 4,

        /// <summary>
        /// Excellent rating (5 stars)
        /// </summary>
        Excellent = 5
    }
}