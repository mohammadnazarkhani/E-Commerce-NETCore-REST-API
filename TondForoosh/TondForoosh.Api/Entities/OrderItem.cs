namespace TondForoosh.Api.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public required int Quantity { get; set; }
        public required decimal TotalPrice { get; set; }

        // Foreign key for Product
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Foreign key for Order
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
