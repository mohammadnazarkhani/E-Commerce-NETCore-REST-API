namespace Domain.DTOs;

public record AddressResponse(
    Guid Id,
    string Street,
    string City,
    string State,
    string Country,
    string PostalCode,
    bool IsDefault
);

public record CreateAddressRequest(
    string Street,
    string City,
    string State,
    string Country,
    string PostalCode,
    bool IsDefault
);

public record UpdateAddressRequest(
    string Street,
    string City,
    string State,
    string Country,
    string PostalCode,
    bool IsDefault
);
