using Core.Persistence.Models;
using Shop.Domain.Enum;

namespace Shop.Domain.RelationalEntities;

public class Discount : Entity<Guid>
{
    public string Name { get; set; } = null!;

    public DiscountUsageType DiscountUsageType { get; set; }

    public decimal Value { get; set; }

    public virtual ICollection<ExcludedCategoryDiscount> ExcludedCategoryDiscounts { get; set; }

    public virtual ICollection<DiscountRoleRelation> DiscountRoles { get; set; }

}
