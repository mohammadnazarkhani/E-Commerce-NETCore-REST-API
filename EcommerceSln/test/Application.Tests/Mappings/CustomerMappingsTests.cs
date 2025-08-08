using Application.DTOs;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;

namespace Application.Tests.Mappings;

public class CustomerMappingsTests
{
    private readonly IMapper _mapper;
    
    public CustomerMappingsTests()
    {
        var mapperConfig = new MapperConfiguration(
            cfg => {
                cfg.AddProfile<CustomerMappings>();
                cfg.AddProfile<AddressMappings>(); // Required for mapping addresses
            }
        );
        
        _mapper = mapperConfig.CreateMapper();
    }
    
    [Fact]
    public void Map_Customer_To_CustomerDto_Should_Map_Correctly()
    {
        // Arrange
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Addresses = new List<Address>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Street = "123 Test St",
                    City = "Test City",
                    State = "Test State",
                    Country = "Test Country",
                    PostalCode = "12345",
                    IsDefault = true
                }
            }
        };

        // Act
        var result = _mapper.Map<CustomerDto>(customer);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(customer.Id);
        result.FirstName.Should().Be(customer.FirstName);
        result.LastName.Should().Be(customer.LastName);
        result.Email.Should().Be(customer.Email);
        result.PhoneNumber.Should().Be(customer.PhoneNumber);
        result.CreatedAt.Should().Be(customer.CreatedAt);
        result.UpdatedAt.Should().Be(customer.UpdatedAt);
        result.Addresses.Should().NotBeNull();
        result.Addresses.Should().HaveCount(1);
    }

    [Fact]
    public void Map_Customer_To_CustomerSummaryDto_Should_Map_Correctly()
    {
        // Arrange
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890"
        };

        // Act
        var result = _mapper.Map<CustomerSummaryDto>(customer);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(customer.Id);
        result.FirstName.Should().Be(customer.FirstName);
        result.LastName.Should().Be(customer.LastName);
        result.Email.Should().Be(customer.Email);
    }

    [Fact]
    public void Map_CreateCustomerDto_To_Customer_Should_Map_Correctly()
    {
        // Arrange
        var createDto = new CreateCustomerDto(
            "John",
            "Doe",
            "john.doe@example.com",
            "1234567890"
        );

        // Act
        var result = _mapper.Map<Customer>(createDto);

        // Assert
        result.Should().NotBeNull();
        result.FirstName.Should().Be(createDto.FirstName);
        result.LastName.Should().Be(createDto.LastName);
        result.Email.Should().Be(createDto.Email);
        result.PhoneNumber.Should().Be(createDto.PhoneNumber);
    }
}
