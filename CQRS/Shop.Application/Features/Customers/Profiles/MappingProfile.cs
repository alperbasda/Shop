using AutoMapper;
using Shop.Application.Features.Customers.Queries.GetWithRolesById;
using Shop.Domain.RelationalEntities;

namespace Shop.Application.Features.Customers.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, GetWithRolesByIdCustomerResponse>()
            .ForMember(w => w.Roles, q => q.MapFrom(c => c.CustomerRoles.Select(w=>w.Role)));
    }
}
