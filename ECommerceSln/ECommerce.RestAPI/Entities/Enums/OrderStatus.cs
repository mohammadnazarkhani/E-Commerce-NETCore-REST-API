namespace ECommerce.RestAPI.Entities.Enums
{
    /// <summary>
    /// Represents the status of an order in the e-commerce system.
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// An order that is currently active and being processed.
        /// </summary>
        Active,
        /// <summary>
        /// An order that has been completed successfully.
        /// Some orders may be completed without being shipped, such as digital products.
        /// </summary>
        Completed,
        /// <summary>
        /// An order that has been cancelled by the user or the system.
        /// It may be due to various reasons such as payment failure or user request.
        Cancelled,
        /// <summary>
        /// An order that is currently pending and awaiting further action.
        /// Is when the order has been placed but not yet processed.
        /// It may involve waiting for payment confirmation or stock availability. 
        /// Meaning that the order is not yet finalized and may still change status.
        /// </summary>
        Pending,
        /// <summary>
        /// An order that has been shipped to the customer.
        /// </summary>
        Shipped,
        /// <summary>
        /// An order that has been refunded to the customer.
        /// It means that the customer has received their money back for the order.
        /// </summary>
        Refunded
    }
}
