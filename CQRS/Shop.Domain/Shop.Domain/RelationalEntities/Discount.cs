using Core.Persistence.Models;
using Shop.Domain.Enum;

namespace Shop.Domain.RelationalEntities;

public class Discount : Entity<Guid>
{
    public Discount()
    {
        DiscountCriteria = new List<DiscountCriterion>();
    }
    public string Name { get; set; } = null!;

    public DiscountUsageType DiscountUsageType { get; set; }

    public decimal Value { get; set; }

    public int Priority { get; set; }

    public virtual ICollection<DiscountCriterion> DiscountCriteria { get; set; }

}
