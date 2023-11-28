using Core.Persistence.Models;

namespace Shop.Domain.MongoEntities;

public class InvoiceItem : MongoEntity<Guid>
{
    public string ProductName { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public int Amount { get; set; }

    public decimal TotalPrice { get; set; }


}
