namespace TondForoosh.Api.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public required int Quantity { get; set; }
        public required decimal TotalPrice { get; set; }

        // Foreign key for Product
        public required int ProductId { get; set; }
        public required Product Product { get; set; }

        // Foreign key for Order
        public required int OrderId { get; set; }
        public required Order Order { get; set; }
    }
}
