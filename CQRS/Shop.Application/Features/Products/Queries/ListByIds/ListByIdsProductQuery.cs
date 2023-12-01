using MediatR;

namespace Shop.Application.Features.Products.Queries.ListByIds;

public class ListByIdsProductQuery : IRequest<List<ListByIdsProductResponse>>
{
    public ListByIdsProductQuery()
    {
        Ids = new List<Guid>();
    }
    public List<Guid> Ids { get; set; }
}
