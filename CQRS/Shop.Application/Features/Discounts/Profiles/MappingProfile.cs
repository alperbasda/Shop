using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Domain.RelationalEntities;

namespace Shop.Application.Features.Discounts.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Discount, ListDynamicDiscountResponse>()
            .ForMember(w => w.Criteria, q => q.MapFrom(x => x.DiscountCriteria));

        CreateMap<Paginate<Discount>, ListModel<ListDynamicDiscountResponse>>();
    }
}
