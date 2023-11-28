using Core.Persistence.Models;

namespace Shop.Domain.RelationalEntities;

public class Category : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}
