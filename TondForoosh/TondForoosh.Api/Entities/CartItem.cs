namespace TondForoosh.Api.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public required int Quantity { get; set; }

        // Foreign key for Product
        public required int ProductId { get; set; }
        public required Product Product { get; set; }

        // Foreign key for Shopping Cart
        public required int ShoppingCartId { get; set; }
        public required ShoppingCart ShoppingCart { get; set; }
    }
}
