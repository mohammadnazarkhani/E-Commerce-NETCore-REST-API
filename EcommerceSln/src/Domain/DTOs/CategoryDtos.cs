namespace Domain.DTOs;

public record CategoryResponse(
    Guid Id,
    string Name,
    string Description,
    int ProductCount
);

public record CreateCategoryRequest(
    string Name,
    string Description
);

public record UpdateCategoryRequest(
    string Name,
    string Description
);
