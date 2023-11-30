using Shop.Application.Features.DiscountCriterias.Queries.ListDynamic;
using Shop.Domain.Enum;

namespace Shop.Application.Features.Discounts.Queries.ListDynamic;

public class ListDynamicDiscountResponse
{
    public string Name { get; set; } = null!;

    public DiscountUsageType DiscountUsageType { get; set; }

    public decimal Value { get; set; }

    public int Priority { get; set; }

    public List<ListDynamicDiscountCriterionResponse> Criteria { get; set; }
}

