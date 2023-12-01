using Core.Persistence.Models;

namespace Shop.Domain.MongoEntities;

public class Invoice : MongoEntity<Guid>
{
    public Invoice()
    {
        InvoiceItems = new List<InvoiceItem>();
    }
    public Guid CustomerId { get; set; }

    public string CustomerFullName { get; set; } = "";

    public string Number { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public decimal DiscountedTotalPrice { get; set; }

    public string UsedDiscounts { get; set; } = "";

    public List<InvoiceItem> InvoiceItems { get; set; }
}
