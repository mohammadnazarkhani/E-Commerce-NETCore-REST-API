using Application.DTOs;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;

namespace Application.Tests.Mappings;

public class AddressMappingsTests
{
    private readonly IMapper _mapper;
    
    public AddressMappingsTests()
    {
        var mapperConfig = new MapperConfiguration(
            cfg => cfg.AddProfile<AddressMappings>()
        );
        
        _mapper = mapperConfig.CreateMapper();
    }
    
    [Fact]
    public void Map_Address_To_AddressDto_Should_Map_Correctly()
    {
        // Arrange
        var address = new Address
        {
            Id = Guid.NewGuid(),
            Street = "123 Test St",
            City = "Test City",
            State = "Test State",
            Country = "Test Country",
            PostalCode = "12345",
            IsDefault = true,
            CustomerId = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // Act
        var result = _mapper.Map<AddressDto>(address);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(address.Id);
        result.Street.Should().Be(address.Street);
        result.City.Should().Be(address.City);
        result.State.Should().Be(address.State);
        result.Country.Should().Be(address.Country);
        result.PostalCode.Should().Be(address.PostalCode);
        result.IsDefault.Should().Be(address.IsDefault);
        result.CustomerId.Should().Be(address.CustomerId);
    }

    [Fact]
    public void Map_CreateAddressDto_To_Address_Should_Map_Correctly()
    {
        // Arrange
        var createDto = new CreateAddressDto(
            "123 Test St",
            "Test City",
            "Test State",
            "Test Country",
            "12345",
            true,
            Guid.NewGuid()
        );

        // Act
        var result = _mapper.Map<Address>(createDto);

        // Assert
        result.Should().NotBeNull();
        result.Street.Should().Be(createDto.Street);
        result.City.Should().Be(createDto.City);
        result.State.Should().Be(createDto.State);
        result.Country.Should().Be(createDto.Country);
        result.PostalCode.Should().Be(createDto.PostalCode);
        result.IsDefault.Should().Be(createDto.IsDefault);
        result.CustomerId.Should().Be(createDto.CustomerId);
    }
}
