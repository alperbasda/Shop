using AutoMapper;
using Core.Persistence.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Repositories;
using Shop.Application.Features.Discounts.Queries.ListDynamic;

namespace Shop.Application.Features.Discounts.Handlers.Queries.ListDynamic;

public class ListDynamicDiscountQueryHandler : IRequestHandler<ListDynamicDiscountQuery, ListModel<ListDynamicDiscountResponse>>
{
    private readonly IDiscountDal _discountDal;
    private readonly IMapper _mapper;
    public ListDynamicDiscountQueryHandler(IDiscountDal discountDal, IMapper mapper)
    {
        _discountDal = discountDal;
        _mapper = mapper;
    }

    public async Task<ListModel<ListDynamicDiscountResponse>> Handle(ListDynamicDiscountQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<ListModel<ListDynamicDiscountResponse>>(await _discountDal.GetListByDynamicAsync(request.DynamicQuery, index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, include: q => q.Include(c => c.DiscountCriteria), cancellationToken: cancellationToken));
    }
}
