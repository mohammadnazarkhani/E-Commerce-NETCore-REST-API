using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class AddressMappings : Profile
{
    public AddressMappings()
    {
        CreateMap<Address, AddressDto>();
        CreateMap<CreateAddressDto, Address>();
        CreateMap<UpdateAddressDto, Address>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
