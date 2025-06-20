namespace ECommerce.RestAPI.Entities.Enums
{
    /// <summary>
    /// Represents the status of an order in the e-commerce system.
    /// </summary>
    public enum PaymentMethod
    {
        /// <summary>
        /// A payment method that is not specified or used.
        /// </summary>
        None = 0,
        /// <summary>
        /// A payment method using a credit card.
        /// </summary>
        CreditCard = 1,
        /// <summary>
        /// A payment method using a gift card.
        /// </summary>
        GiftCard = 2
    }
}
