using Core.Persistence.Models;
using Shop.Domain.Enum;

namespace Shop.Domain.RelationalEntities;

public class Discount : Entity<Guid>
{
    public string Name { get; set; }

    public DiscountUsageType DiscountUsageType { get; set; }

    public double Value { get; set; }
}
