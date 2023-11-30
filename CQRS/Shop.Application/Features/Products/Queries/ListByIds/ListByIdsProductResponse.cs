namespace Shop.Application.Features.Products.Queries.ListByIds;

public class ListByIdsProductResponse
{
    public Guid Id { get; set; }

    public Guid CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public decimal UnitPrice { get; set; }

}
