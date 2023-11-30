using Shop.Domain.MongoEntities;

namespace Shop.Application.Features.Discounts.Commands.CalculateInvoice;

public class CalculateInvoiceDiscountResponse
{
    public Invoice Invoice { get; set; }
}
