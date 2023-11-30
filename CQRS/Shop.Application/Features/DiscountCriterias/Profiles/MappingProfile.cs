using AutoMapper;
using Shop.Application.Features.DiscountCriterias.Queries.ListDynamic;
using Shop.Domain.RelationalEntities;


namespace Shop.Application.Features.DiscountCriterias.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DiscountCriterion, ListDynamicDiscountCriterionResponse>();
    }
}
