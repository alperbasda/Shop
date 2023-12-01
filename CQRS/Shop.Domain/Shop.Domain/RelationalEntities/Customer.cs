using Core.Persistence.Models;

namespace Shop.Domain.RelationalEntities;

public class Customer : Entity<Guid>
{
    public Customer()
    {
        CustomerRoles = new List<CustomerRoleRelation>();
    }
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<CustomerRoleRelation> CustomerRoles { get; set; }

}
