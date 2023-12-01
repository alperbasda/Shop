using Shop.Domain.Enum;

namespace Shop.Application.Features.DiscountCriterias.Queries.ListDynamic;

public class ListDynamicDiscountCriterionResponse
{
    public Guid DiscountId { get; set; }

    public DiscountAssignType DiscountAssignType { get; set; }

    public string Criterion { get; set; } = null!;

    public bool UseForDirectCondition { get; set; }
} 