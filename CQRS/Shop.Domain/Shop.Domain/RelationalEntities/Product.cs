using Core.Persistence.Models;

namespace Shop.Domain.RelationalEntities;

public class Product : Entity<Guid>
{
    public Guid CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public string Name { get; set; }


}
