using Core.Persistence.Models;

namespace Shop.Domain.RelationalEntities;

public class DiscountRoleRelation : Entity<Guid>
{
    public Guid RoleId { get; set; }

    public virtual Role Role { get; set; }

    public Guid DiscountId { get; set; }

    public virtual Discount Discount { get; set; }


}
