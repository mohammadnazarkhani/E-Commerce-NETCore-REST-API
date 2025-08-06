using Domain.Entities;

namespace Application.Specifications.ProductSpecifications;

public class ProductByNameSpecification : BaseSpecification<Product>
{
    public ProductByNameSpecification(string name)
        : base(p => p.Name.ToLower() == name.ToLower())
    {
    }
}

public class ProductBySkuSpecification : BaseSpecification<Product>
{
    public ProductBySkuSpecification(string sku)
        : base(p => p.SKU.ToLower() == sku.ToLower())
    {
    }
}
