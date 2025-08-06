using Domain.Entities;

namespace Application.Specifications.CategorySpecifications;

public class CategoryByIdSpecification : BaseSpecification<Category>
{
    public CategoryByIdSpecification(Guid id)
        : base(c => c.Id == id)
    {
    }
}
