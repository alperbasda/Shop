using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Repositories;
using Shop.Application.Features.Products.Queries.ListByIds;
using Shop.Application.Features.Products.Rules;

namespace Shop.Application.Features.Products.Handlers.Queries.ListByIds;

public class ListByIdsProductQueryHandler : IRequestHandler<ListByIdsProductQuery, List<ListByIdsProductResponse>>
{
    ProductBusinessRules _productBusinessRules;
    IProductDal _productDal;
    IMapper _mapper;
    public ListByIdsProductQueryHandler(IProductDal productDal, IMapper mapper, ProductBusinessRules productBusinessRules)
    {
        _productDal = productDal;
        _mapper = mapper;
        _productBusinessRules = productBusinessRules;
    }

    public async Task<List<ListByIdsProductResponse>> Handle(ListByIdsProductQuery request, CancellationToken cancellationToken)
    {
        var datas = await _productDal.GetListAsync(w => request.Ids.Contains(w.Id), cancellationToken: cancellationToken);

        await _productBusinessRules.ThrowExceptionIfDataNull(datas.Items);

        return _mapper.Map<List<ListByIdsProductResponse>>(datas.Items);
    }
}
