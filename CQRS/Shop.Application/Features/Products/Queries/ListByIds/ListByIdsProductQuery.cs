using MediatR;

namespace Shop.Application.Features.Products.Queries.ListByIds;

public class ListByIdsProductQuery : IRequest<List<ListByIdsProductResponse>>
{
    public List<Guid> Ids { get; set; }
}
