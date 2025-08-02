namespace Domain.DTOs;

public record CustomerResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    IEnumerable<AddressResponse> Addresses
);

public record CreateCustomerRequest(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
);

public record UpdateCustomerRequest(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
);
