using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class CustomerMappings : Profile
{
    public CustomerMappings()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<Customer, CustomerSummaryDto>();
        
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<UpdateCustomerDto, Customer>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
