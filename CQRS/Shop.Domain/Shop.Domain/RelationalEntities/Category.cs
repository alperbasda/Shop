using Core.Persistence.Models;

namespace Shop.Domain.RelationalEntities;

public class Category : Entity<Guid>
{
    public Category()
    {
        Products = new List<Product>();
    }
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; }

}
