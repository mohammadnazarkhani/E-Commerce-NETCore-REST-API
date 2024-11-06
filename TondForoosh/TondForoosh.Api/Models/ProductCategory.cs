namespace TondForoosh.Api.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        // Navigation property for products
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
