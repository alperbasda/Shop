using Core.Persistence.Models;

namespace Shop.Domain.RelationalEntities;

public class CustomerRoleRelation : Entity<Guid>
{
    public Guid RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public Guid CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public DateTime? LastValidTime { get; set; }
}
