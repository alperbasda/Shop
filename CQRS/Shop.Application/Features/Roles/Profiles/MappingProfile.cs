using AutoMapper;
using Shop.Application.Features.Roles.Queries;
using Shop.Domain.RelationalEntities;


namespace Shop.Application.Features.Roles.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Role, GetByUserIdRoleResponse>();
    }
}
