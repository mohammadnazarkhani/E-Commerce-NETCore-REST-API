namespace Application.DTOs;

public record CustomerDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    ICollection<AddressDto>? Addresses = null
);

public record CreateCustomerDto(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
);

public record UpdateCustomerDto(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
);

public record CustomerSummaryDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email
);
