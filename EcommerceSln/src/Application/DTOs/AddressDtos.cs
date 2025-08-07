using Domain.Entities;

namespace Application.DTOs;

public record AddressDto(
    Guid Id,
    string Street,
    string City,
    string State,
    string Country,
    string PostalCode,
    bool IsDefault,
    Guid CustomerId
);

public record CreateAddressDto(
    string Street,
    string City,
    string State,
    string Country,
    string PostalCode,
    bool IsDefault,
    Guid CustomerId
);

public record UpdateAddressDto(
    string Street,
    string City,
    string State,
    string Country,
    string PostalCode,
    bool IsDefault
);
