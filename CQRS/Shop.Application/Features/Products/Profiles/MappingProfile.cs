using AutoMapper;
using Shop.Application.Features.Products.Queries.ListByIds;
using Shop.Domain.RelationalEntities;

namespace Shop.Application.Features.Products.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ListByIdsProductResponse>();
    }
}
