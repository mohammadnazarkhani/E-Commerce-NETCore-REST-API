using System.Collections.Generic;
using TondForoosh.Api.Dtos.Product;

namespace TondForoosh.Api.Dtos.Category
{
    public record class CategoryDetailDto(
        int Id,
        string Title,
        List<ProductDto> Products);
}
