namespace TondForoosh.Api.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public required decimal TotalPrice { get; set; }
        public required DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public required string OrderStatus { get; set; }

        // Foreign key for User
        public int UserId { get; set; }
        public User User { get; set; }

        // Navigation property for OrderItems
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
