using Core.Persistence.Models;

namespace Shop.Domain.RelationalEntities;

public class ExcludedCategoryDiscount : Entity<Guid>
{
    public Guid CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public Guid DiscountId { get; set; }

    public virtual Discount Discount { get; set; }
}
