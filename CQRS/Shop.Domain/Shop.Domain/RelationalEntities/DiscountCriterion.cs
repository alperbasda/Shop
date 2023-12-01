using Core.Persistence.Models;
using Shop.Domain.Enum;

namespace Shop.Domain.RelationalEntities;

public class DiscountCriterion : Entity<Guid>
{
    public Guid DiscountId { get; set; }

    public virtual Discount Discount { get; set; } = null!;

    public DiscountAssignType DiscountAssignType { get; set; }

    public string Criterion { get; set; } = null!;

    public bool UseForDirectCondition { get; set; }
}
