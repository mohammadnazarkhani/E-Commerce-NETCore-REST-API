namespace TondForoosh.Api.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        // Foreign key for User
        public int UserId { get; set; }
        public User User { get; set; }

        // Navigation property for CartItems
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
