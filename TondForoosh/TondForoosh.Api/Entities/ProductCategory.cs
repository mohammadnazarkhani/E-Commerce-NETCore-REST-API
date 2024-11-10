using TondForoosh.Api.Common;
using TondForoosh.Api.Dtos.Category;

namespace TondForoosh.Api.Entities
{
    public class ProductCategory : IUpdatable<UpdateCategoryDto>
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        // Navigation property for products
        public List<Product> Products { get; set; } = new List<Product>();

        // Implementation of UpdateEntity method for ProductCategory
        public void UpdateEntity(UpdateCategoryDto dto)
        {
            Title = dto.Title;
        }
    }
}
