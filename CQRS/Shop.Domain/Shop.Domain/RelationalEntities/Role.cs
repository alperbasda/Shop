using Core.Persistence.Models;

namespace Shop.Domain.RelationalEntities;

public class Role : Entity<Guid>
{
    public string Name { get; set; } = null!;

    public virtual ICollection<CustomerRoleRelation> RoleCustomers { get; set; }

}
