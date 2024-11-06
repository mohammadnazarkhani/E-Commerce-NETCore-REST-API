namespace TondForoosh.Api.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public required int Quantity { get; set; }

        // Foreign key for Product
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Foreign key for Shopping Cart
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
