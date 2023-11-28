using Core.Persistence.Models;

namespace Shop.Domain.MongoEntities;

public class Invoice : MongoEntity<Guid>
{
    public Guid CustomerId { get; set; }

    public string CustomerFullName { get; set; }

    public string Number { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public List<InvoiceItem> InvoiceItems { get; set; }
}
